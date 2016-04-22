using Microsoft.AspNet.Identity.EntityFramework;
using RealtyInvest.DataModel.Repositories;
using System.Linq;
using Microsoft.AspNet.Identity;

namespace RealtyInvest.DataModel.Impl
{
    public class RoleRepository : Repository<IdentityRole, string>, IRoleRepository
    {
        public RoleRepository(RealtyInvestDbContext contextDb) : base(contextDb)
        {
            RoleManager = new RoleManager<IdentityRole>( new RoleStore<IdentityRole>(ContextDb));
        }

        public override IdentityRole GetById(string id)
        {
            return ContextDb.Roles.First(x => x.Id == id);
        }

        public RoleManager<IdentityRole> RoleManager { get;  }
    }
}