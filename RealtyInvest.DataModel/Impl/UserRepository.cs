using RealtyInvest.DataModel.Entites;
using RealtyInvest.DataModel.Repositories;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RealtyInvest.DataModel.Impl
{
    public class UserRepository : Repository<RealtyInvestUser, string>, IUserRepository
    {
        public UserRepository(RealtyInvestDbContext contextDb) : base(contextDb)
        {
            UserManager = new UserManager<RealtyInvestUser>(new UserStore<RealtyInvestUser>(ContextDb));
        }

        public override RealtyInvestUser GetById(string id) => ContextDb.Users.First(x => x.Id == id);
        public UserManager<RealtyInvestUser> UserManager { get; }
    }
}