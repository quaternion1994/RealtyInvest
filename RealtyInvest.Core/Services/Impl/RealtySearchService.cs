using System.Linq;
using RealtyInvest.Common.ServiceResult;
using RealtyInvest.DataModel.Models;
using RealtyInvest.DataModel.UnitsOfWorks;
using RealtyInvest.DataModel.ViewModels;
using RealtyInvest.DataModel.ViewModels.Manage;

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

        public ServiceResult<SearchResult[]> AutoSearch(string userid, string text)
        {
            ServiceResult<SearchResult[]> result = new ServiceResult<SearchResult[]>();
            using (var uow = _factory.CreateUnitOfWork())
            {
                result.Value = uow.RealEstateRepository
                    .All(x => x.Owner.Id == userid && 
                    (x.Location.City.Contains(text) || x.Location.Country.Contains(text) 
                    || x.Name.Contains(text) || x.Owner.UserName.Contains(text) || x.Description.Contains(text)))
                    .Select(x => new SearchResult
                    {
                        RealtyId = x.Id,
                        Description = x.Description,
                        Location = x.Location,
                        RealtyName = x.Name,
                        PictureUrl = x.MainPictureUrl,
                        Price = x.Price
                    }).ToArray();
                
                result.ServiceStatus = Status.Success;
            }
            return result;
        }
    }
}