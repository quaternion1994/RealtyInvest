using System.Linq;
using Latitude.DataAccess.Entities;

namespace Latitude.DataAccess.Repositories.Impl
{
    public class AccountRepository : Repository<Account, int>, IAccountRepository
    {
        public AccountRepository(ArgusDbContext context) : base(context)
        {
        }

        public override Account GetById(int id)
        {
            return _context.Accounts.SingleOrDefault(x => x.Id == id);
        }
    }
}
