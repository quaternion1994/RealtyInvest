using System.Web.Mvc;
using RealtyInvest.DataModel.Repositories;

namespace RealtyInvest.Web.Areas.Admin.Controllers
{
    public class MainController : Controller
    {
        private readonly IRealEstateRepository _repository;
        public MainController(IRealEstateRepository repository)
        {
            this._repository = repository;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
