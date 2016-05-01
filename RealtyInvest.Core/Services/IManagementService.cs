using RealtyInvest.Common.ServiceResult;
using RealtyInvest.DataModel.ViewModels.Manage;

namespace RealtyInvest.Core.Services
{
    public interface IManagementService
    {
        ServiceResult<RealtyManageViewModel[]> GetRealtyListForUser(string userid);
        ServiceResult<RealtyManageViewModel> GetRealtyEstate(string userid, int id);
        ServiceResult<RealtyManageViewModel> SetRealtyEstate(string userid, RealtyManageViewModel model);
    }
}