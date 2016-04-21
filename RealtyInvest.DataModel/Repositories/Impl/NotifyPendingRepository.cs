using System.Linq;
using Latitude.DataAccess.Entities;

namespace Latitude.DataAccess.Repositories.Impl
{
    public class NotifyPendingRepository : Repository<NotifyPending, int>, INotifyPendingRepository
    {
        public NotifyPendingRepository(ArgusDbContext context) : base(context)
        {
        }

        public override NotifyPending GetById(int id)
        {
            return _context.NotifyPendings.SingleOrDefault(x => x.Id == id);
        }
    }
}
