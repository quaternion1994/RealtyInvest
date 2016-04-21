using System.Linq;
using Latitude.DataAccess.Entities;

namespace Latitude.DataAccess.Repositories.Impl
{
    public class NotifySetupRepository : Repository<NotifySetup, int>, INotifySetupRepository
    {
        public NotifySetupRepository(ArgusDbContext context) : base(context)
        {
        }

        public override NotifySetup GetById(int id)
        {
            return _context.NotifySetups.SingleOrDefault(x => x.Id == id);
        }
    }
}
