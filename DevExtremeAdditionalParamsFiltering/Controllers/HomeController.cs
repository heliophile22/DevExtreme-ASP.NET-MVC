using System.Web.Mvc;

namespace DevExtremeAdditionalParamsFiltering.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult BackendParamsFilter()
        {
            return View();
        }

        public ActionResult DynamicParamsFilter()
        {
            return View();
        }

        public ActionResult StaticParamsFilter()
        {
            return View();
        }
    }
}