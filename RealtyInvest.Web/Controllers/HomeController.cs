using System.Web.Mvc;

namespace RealtyInvest.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RealtyView(int? id)
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Realty()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}