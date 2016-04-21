using System.Linq;
using Latitude.DataAccess.Entities;

namespace Latitude.DataAccess.Repositories.Impl
{
    public class GroupRepository : Repository<Group, int>, IGroupRepository
    {
        public GroupRepository(ArgusDbContext context) : base(context)
        {
        }

        public override Group GetById(int id)
        {
            return _context.Groups.SingleOrDefault(x => x.Id == id);
        }

        public IQueryable<Group> GetGroupsForClient(int clientId)
        {
            return _context.Groups.Where(p => p.RefClientId == clientId);
        }
    }
}
