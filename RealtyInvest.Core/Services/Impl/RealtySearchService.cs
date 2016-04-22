using RealtyInvest.Common.ServiceResult;
using RealtyInvest.DataModel.Models;
using RealtyInvest.DataModel.UnitsOfWorks;

namespace RealtyInvest.Core.Services.Impl
{
    public class RealtySearchService : IRealtySearchService
    {
        private readonly IUnitOfWorkFactory _factory;
        public RealtySearchService(IUnitOfWorkFactory factory)
        {
            _factory = factory;
        }

        public ServiceResult<ServiceResult[]> Search(SearchModel model)
        {
            ServiceResult<ServiceResult[]> result = new ServiceResult<ServiceResult[]>();
            using (var uow = _factory.CreateUnitOfWork())
            {
                result.ServiceStatus = Status.Success;
            }
            return result;
        }
    }
}