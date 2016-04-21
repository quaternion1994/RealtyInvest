using System.Linq;
using Latitude.DataAccess.Entities;

namespace Latitude.DataAccess.Repositories.Impl
{
    public class SessionRepository : Repository<Session, int>, ISessionRepository
    {
        public SessionRepository(ArgusDbContext context) : base(context)
        {
        }

        public override Session GetById(int id)
        {
            return _context.Sessions.SingleOrDefault(x => x.Id == id);
        }
    }
}
