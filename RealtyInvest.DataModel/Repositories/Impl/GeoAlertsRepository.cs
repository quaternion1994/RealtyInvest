using System.Linq;
using Latitude.DataAccess.Entities;

namespace Latitude.DataAccess.Repositories.Impl
{
    public class GeoAlertsRepository : Repository<GeoAlert, int>, IGeoAlertsRepository
    {
        public GeoAlertsRepository(ArgusDbContext context) : base(context)
        {
        }

        public override GeoAlert GetById(int id)
        {
            return _context.GeoAlerts.SingleOrDefault(x => x.Id == id);
        }

        public IQueryable<GeoAlert> GetGeoAlertsForClient(int clientId)
        {
            return _context.GeoAlerts.Where(p => p.RefClientId == clientId);
        }

        public GeoAlert GetById(int clientId, int geoAlertId)
        {
            return _context.GeoAlerts.FirstOrDefault(p => p.RefClientId == clientId && p.Id == geoAlertId);
        }
    }
}
