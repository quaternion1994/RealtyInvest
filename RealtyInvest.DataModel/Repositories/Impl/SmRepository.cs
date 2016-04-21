using System.Linq;
using Latitude.DataAccess.Entities;

namespace Latitude.DataAccess.Repositories.Impl
{
    public class SmRepository : Repository<Sm, int>, ISmRepository
    {
        public SmRepository(ArgusDbContext context) : base(context)
        {
        }

        public override Sm GetById(int id)
        {
            return _context.Sms.SingleOrDefault(x => x.Id == id);
        }
    }
}
