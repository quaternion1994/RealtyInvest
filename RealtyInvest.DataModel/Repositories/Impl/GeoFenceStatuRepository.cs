using System.Linq;
using Latitude.DataAccess.Entities;

namespace Latitude.DataAccess.Repositories.Impl
{
    public class GeoFenceStatuRepository : Repository<GeoFenceStatu, int>, IGeoFenceStatuRepository
    {
        public GeoFenceStatuRepository(ArgusDbContext context) : base(context)
        {
        }

        public override GeoFenceStatu GetById(int id)
        {
            return _context.GeoFenceStatus.SingleOrDefault(x => x.Id == id);
        }
    }
}
