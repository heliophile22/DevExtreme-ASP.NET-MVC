using System.Net.Http;
using System.Web.Http;
using DevExtremeAdditionalParamsFiltering.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DevExtremeAdditionalParamsFiltering.Controllers
{
    public class SampleDataController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetByBackendParams(DataSourceLoadOptions loadOptions)
        {
            int? TenantID = 24;
            int? CompanyID = 1022;

            var customFilters = new List<object>();

            if (TenantID.HasValue)
            {
                customFilters.Add(new object[] { "TenantID", "=", TenantID.Value });
            }
            if (CompanyID.HasValue)
            {
                customFilters.Add(new object[] { "CompanyID", "=", CompanyID.Value });
            }

            loadOptions.Filter = MergeFilters(loadOptions, customFilters);

            return Request.CreateResponse(DataSourceLoader.Load(SampleData.Orders, loadOptions));
        }

        private List<object> MergeFilters(DataSourceLoadOptions loadOptions, List<object> customFilters)
        {
            if (loadOptions.Filter != null)
            {
                if (customFilters.Count > 0)
                {
                    customFilters.Insert(0, loadOptions.Filter);
                }
                else
                {
                    customFilters.Add(loadOptions.Filter);
                }
            }
            return customFilters;
        }

        [HttpGet]
        public HttpResponseMessage GetByDynamicParams(DataSourceLoadOptions loadOptions, string userData)
        {
            var filters = JsonConvert.DeserializeObject<FilterModel>(userData);
            var customFilters = new List<object>();

            if (!string.IsNullOrEmpty(filters.TenantID))
            {
                customFilters.Add(new object[] { "TenantID", "=", filters.TenantID });
            }
            if (!string.IsNullOrEmpty(filters.CompanyID))
            {
                customFilters.Add(new object[] { "CompanyID", "=", filters.CompanyID });
            }

            loadOptions.Filter = MergeFilters(loadOptions, customFilters);

            return Request.CreateResponse(DataSourceLoader.Load(SampleData.Orders, loadOptions));
        }

        [HttpGet]
        public HttpResponseMessage GetByStaticParams(DataSourceLoadOptions loadOptions, int? TenantID, int? CompanyID)
        {
            var customFilters = new List<object>();

            if (TenantID.HasValue)
            {
                customFilters.Add(new object[] { "TenantID", "=", TenantID.Value });
            }
            if (CompanyID.HasValue)
            {
                customFilters.Add(new object[] { "CompanyID", "=", CompanyID.Value });
            }

            loadOptions.Filter = MergeFilters(loadOptions, customFilters);

            return Request.CreateResponse(DataSourceLoader.Load(SampleData.Orders, loadOptions));
        }
    }
}