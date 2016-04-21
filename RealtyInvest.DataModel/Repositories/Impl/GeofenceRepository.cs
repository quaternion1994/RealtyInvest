using System.Linq;
using Latitude.DataAccess.Entities;

namespace Latitude.DataAccess.Repositories.Impl
{
    public class GeofenceRepository : Repository<Geofence, int>, IGeofenceRepository
    {
        public GeofenceRepository(ArgusDbContext context) : base(context)
        {
        }

        public override Geofence GetById(int id)
        {
            return _context.Geofences.SingleOrDefault(x => x.Id == id);
        }
    }
}
