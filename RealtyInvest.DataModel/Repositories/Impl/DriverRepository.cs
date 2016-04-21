using System.Linq;
using Latitude.DataAccess.Entities;

namespace Latitude.DataAccess.Repositories.Impl
{
    public class DriverRepository : Repository<Driver, int>, IDriverRepository
    {
        public DriverRepository(ArgusDbContext context) : base(context)
        {
        }

        public override Driver GetById(int id)
        {
            return _context.Drivers.SingleOrDefault(x => x.Id == id);
        }
    }
}
