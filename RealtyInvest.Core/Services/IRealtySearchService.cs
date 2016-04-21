using RealtyInvest.Common.ServiceResult;
using RealtyInvest.DataModel.Models;

namespace RealtyInvest.Core.Services
{
    public interface IRealtySearchService
    {
        ServiceResult<ServiceResult[]> Search(SearchModel model);
    }
}