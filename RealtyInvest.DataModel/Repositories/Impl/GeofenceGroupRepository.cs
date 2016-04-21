using System.Linq;
using Latitude.DataAccess.Entities;

namespace Latitude.DataAccess.Repositories.Impl
{
    public class GeofenceGroupRepository : Repository<GeofenceGroup, int>, IGeofenceGroupRepository
    {
        public GeofenceGroupRepository(ArgusDbContext context) : base(context)
        {
        }

        public override GeofenceGroup GetById(int id)
        {
            return _context.GeofenceGroups.SingleOrDefault(x => x.Id == id);
        }
    }
}
