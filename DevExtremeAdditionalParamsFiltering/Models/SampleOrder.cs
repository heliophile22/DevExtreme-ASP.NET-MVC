using System;

namespace DevExtremeAdditionalParamsFiltering.Models {
    public class SampleOrder {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string ShipCountry { get; set; }
        public string ShipCity { get; set; }
        public int TenantID { get; set; }
        public int CompanyID { get; set; }
    }
}