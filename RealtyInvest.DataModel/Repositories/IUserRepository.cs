using Microsoft.AspNet.Identity;
using RealtyInvest.DataModel.Entites;
using RealtyInvest.DataModel.Impl;

namespace RealtyInvest.DataModel.Repositories
{
    public interface IUserRepository : IRepository<RealtyInvestUser, string>
    {
        UserManager<RealtyInvestUser> UserManager { get;  }
    }
}