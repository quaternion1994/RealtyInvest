using System.Linq;
using Latitude.DataAccess.Entities;

namespace Latitude.DataAccess.Repositories.Impl
{
    public class GroupSelectRepository : Repository<GroupSelect, int>, IGroupSelectRepository
    {
        public GroupSelectRepository(ArgusDbContext context) : base(context)
        {
        }

        public override GroupSelect GetById(int id)
        {
            return _context.GroupSelect.SingleOrDefault(x => x.Id == id);
        }

        public IQueryable<GroupSelect> GetVehiclesByGroupAndClientId(int clientId, int groupId)
        {
            return _context.GroupSelect.Where(p => p.RefClientId == clientId && p.RefGroupId == groupId);
        } 
    }
}
