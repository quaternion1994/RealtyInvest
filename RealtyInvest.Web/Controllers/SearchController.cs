using System.Web.Mvc;
using RealtyInvest.Core.Services;
using RealtyInvest.DataModel.Models;
using System.Linq;
using Microsoft.AspNet.Identity;

namespace RealtyInvest.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly IRealtySearchService _realtySearch;
        public SearchController(IRealtySearchService searchService)
        {
            _realtySearch = searchService;
        }

        // GET: /
        public ActionResult Index()
        {
            return View();
        }

        // GET: Autocomplete
        public ActionResult Autocomplete(string searchString)
        {
            var result = _realtySearch.AutoSearch(User.Identity.GetUserId(), searchString);
            if (result.ServiceStatus != Common.ServiceResult.Status.Success)
                return RedirectToAction("Index");

            var data = result.Value.Select(x => new
            {
                x.RealtyName
            });

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        // POST: Search
        [HttpPost]
        public ActionResult Results(SearchModel model)
        {
            var result = _realtySearch.Search(model);
            if (result.ServiceStatus != Common.ServiceResult.Status.Success)
                return RedirectToAction("Index");

            return View(result.Value);
        }
    }
}