using System.Web.Mvc;
using RealtyInvest.Core.Services;
using RealtyInvest.DataModel.Models;

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
        // POST: Search
        [HttpPost]
        public ActionResult Results(SearchModel model)
        {
            var result = _realtySearch.Search(model);
            if (result.ServiceStatus != Common.ServiceResult.Status.Success)
                return RedirectToAction("Index");

            return View();
        }
    }
}