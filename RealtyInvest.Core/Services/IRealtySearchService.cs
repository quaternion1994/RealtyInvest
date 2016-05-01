using RealtyInvest.Common.ServiceResult;
using RealtyInvest.DataModel.Models;
using RealtyInvest.DataModel.ViewModels;

namespace RealtyInvest.Core.Services
{
    public interface IRealtySearchService
    {
        ServiceResult<SearchResult[]> Search(SearchModel model);
    }
}