using System.Linq;
using Latitude.DataAccess.Entities;

namespace Latitude.DataAccess.Repositories
{
    public interface IVehicleRepository : IRepository<Vehicle, int>
    {
        IQueryable<Vehicle> GetVehiclesForClient(int clientId);
        Vehicle GetVehicleForClient(int clientId, int vehicleId);
    }
}