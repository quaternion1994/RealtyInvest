using System.Web.Mvc;
using RealtyInvest.Core.Services;
using Microsoft.AspNet.Identity;
using RealtyInvest.DataModel.ViewModels.Manage;

namespace RealtyInvest.Web.Controllers
{
    public class InvestorManageController : Controller
    {
        private readonly IManagementService _manService;

        public InvestorManageController(IManagementService manService)
        {
            _manService = manService;
        }

        // GET: InvestorManage
        [Authorize(Roles = "Owner, Investor")]
        public ActionResult Index()
        {
            return View();
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
    }
}