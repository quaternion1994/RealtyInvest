using System.Linq;
using Latitude.DataAccess.Entities;

namespace Latitude.DataAccess.Repositories.Impl
{
    public class GroupSelectUserRepository : Repository<GroupSelectUser, int>, IGroupSelectUserRepository
    {
        public GroupSelectUserRepository(ArgusDbContext context) : base(context)
        {
        }

        public override GroupSelectUser GetById(int id)
        {
            return _context.GroupSelectUser.SingleOrDefault(x => x.Id == id);
        }

        public IQueryable<GroupSelectUser> GetUserGroups(int userId)
        {
            return _context.GroupSelectUser.Where(x => x.RefUserId == userId);
        }
    }
}