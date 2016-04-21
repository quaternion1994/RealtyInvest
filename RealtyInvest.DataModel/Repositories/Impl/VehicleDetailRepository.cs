using System.Linq;
using Latitude.DataAccess.Entities;

namespace Latitude.DataAccess.Repositories.Impl
{
    public class VehicleDetailRepository : Repository<VehicleDetail, int>, IVehicleDetailRepository
    {
        public VehicleDetailRepository(ArgusDbContext context) : base(context)
        {
        }

        public override VehicleDetail GetById(int id)
        {
            return _context.VehicleDetails.SingleOrDefault(x => x.Vid == id);
        }
    }
}
