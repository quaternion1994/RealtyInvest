using System.Linq;
using Latitude.DataAccess.Entities;

namespace Latitude.DataAccess.Repositories.Impl
{
    public class UserRepository : Repository<User, int>, IUserRepository
    {
        public UserRepository(ArgusDbContext context) : base(context)
        {
        }

        public override User GetById(int id)
        {
            return _context.Users.SingleOrDefault(x => x.Id == id);
        }

        public User GetByEmail(string email)
        {
            return _context.Users.SingleOrDefault(p => p.Email == email);
        }
    }
}
