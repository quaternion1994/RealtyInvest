using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RealtyInvest.DataModel.Repositories
{
    public interface IRoleRepository : IRepository<IdentityRole, string>
    {
        RoleManager<IdentityRole> RoleManager { get; }
    }
}