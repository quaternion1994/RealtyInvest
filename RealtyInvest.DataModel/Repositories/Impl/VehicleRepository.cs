using System.Linq;
using Latitude.DataAccess.Entities;

namespace Latitude.DataAccess.Repositories.Impl
{
    public class VehicleRepository : Repository<Vehicle, int>, IVehicleRepository
    {
        public VehicleRepository(ArgusDbContext context) : base(context)
        {
        }

        public override Vehicle GetById(int id)
        {
            return _context.Vehicles.SingleOrDefault(x => x.Vid == id);
        }

        public IQueryable<Vehicle> GetVehiclesForClient(int clientId)
        {
            return _context.Vehicles.Where(p => p.RefClientId == clientId);
        }

        public Vehicle GetVehicleForClient(int clientId, int vehicleId)
        {
            return _context.Vehicles.FirstOrDefault(p => p.Vid == vehicleId && p.RefClientId == clientId);
        }
    }
}
