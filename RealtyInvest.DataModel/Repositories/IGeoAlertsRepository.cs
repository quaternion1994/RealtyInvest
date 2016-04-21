using System.Linq;
using Latitude.DataAccess.Entities;

namespace Latitude.DataAccess.Repositories
{
    public interface IGeoAlertsRepository : IRepository<GeoAlert, int>
    {
        IQueryable<GeoAlert> GetGeoAlertsForClient(int clientId);
        GeoAlert GetById(int clientId, int geoAlertId);
    }
}