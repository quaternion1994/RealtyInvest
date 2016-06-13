using System.Web.Mvc;
using RealtyInvest.Core.Services;
using Microsoft.AspNet.Identity;
using RealtyInvest.Common;
using RealtyInvest.DataModel.ViewModels.Manage;

namespace RealtyInvest.Web.Controllers
{
    public class InvestorManageController : Controller
    {
        private readonly IManagementService _manService;
        private readonly IForecastService _forecastService;

        public InvestorManageController(IManagementService manService, IForecastService forecastService)
        {
            _manService = manService;
            _forecastService = forecastService;
        }

        // GET: InvestorManage
        [Authorize(Roles = "Owner, Investor")]
        public ActionResult Index()
        {
            return RedirectToAction("MyEstate");
        }

        [Authorize(Roles = "Owner")]
        public ActionResult MyEstate()
        {
            var result = _manService.GetRealtyListForUser(User.Identity.GetUserId());
            if (result.ServiceStatus != Common.ServiceResult.Status.Success)
                return null;

            return View(result.Value);
        }

        [Authorize(Roles = "Owner")]
        public ActionResult EditEstate(int id)
        {
            var result = _manService.GetRealtyEstate(User.Identity.GetUserId(), id);
            if (result.ServiceStatus != Common.ServiceResult.Status.Success)
                return null;

            return View(result.Value);
        }

        [Authorize(Roles = "Owner")]
        [HttpPost]
        public ActionResult EditEstate(RealtyManageViewModel model)
        {
            var result = _manService.SetRealtyEstate(User.Identity.GetUserId(), model);
            if (result.ServiceStatus != Common.ServiceResult.Status.Success)
                return null;

            return RedirectToAction("MyEstate");
        }

        [Authorize(Roles = "Owner")]
        public ActionResult Forecast()
        {
            return View();
        }

        [Authorize(Roles = "Owner")]
        [HttpPost]
        public ActionResult Forecast(HistoryPeriod period)
        {
            var result = _forecastService.GetLandPriceForecast(period, Server.MapPath("~/Content/stat.txt"));
            if (result.ServiceStatus != Common.ServiceResult.Status.Success)
                return null;

            return Json(result.Value);
        }
    }
}