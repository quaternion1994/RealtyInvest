using RealtyInvest.Common.ServiceResult;
using RealtyInvest.DataModel.Models;
using RealtyInvest.DataModel.UnitsOfWorks;
using RealtyInvest.DataModel.ViewModels;

namespace RealtyInvest.Core.Services.Impl
{
    public class RealtySearchService : IRealtySearchService
    {
        private readonly IUnitOfWorkFactory _factory;
        public RealtySearchService(IUnitOfWorkFactory factory)
        {
            _factory = factory;
        }

        public ServiceResult<SearchResult[]> Search(SearchModel model)
        {
            ServiceResult<SearchResult[]> result = new ServiceResult<SearchResult[]>();
            using (var uow = _factory.CreateUnitOfWork())
            {
                result.Value = new SearchResult[]
                {
                    new SearchResult {Price = 10, RealtyName = "Dom v tsarskom sele", PictureUrl = "http://storage.googleapis.com/bd-ua-01/buildings/11762.jpg" },
                    new SearchResult {Price = 10, RealtyName = "Dom v tsarskom sele", PictureUrl = "http://storage.googleapis.com/bd-ua-01/buildings/11762.jpg" },
                    new SearchResult {Price = 10, RealtyName = "Dom v tsarskom sele", PictureUrl = "http://storage.googleapis.com/bd-ua-01/buildings/11762.jpg" },
                    new SearchResult {Price = 10, RealtyName = "Dom v tsarskom sele", PictureUrl = "http://storage.googleapis.com/bd-ua-01/buildings/11762.jpg" },
                    new SearchResult {Price = 10, RealtyName = "Dom v tsarskom sele", PictureUrl = "http://storage.googleapis.com/bd-ua-01/buildings/11762.jpg" },
                    new SearchResult {Price = 10, RealtyName = "Dom v tsarskom sele", PictureUrl = "http://storage.googleapis.com/bd-ua-01/buildings/11762.jpg" }
                };
                result.ServiceStatus = Status.Success;
            }
            return result;
        }
    }
}