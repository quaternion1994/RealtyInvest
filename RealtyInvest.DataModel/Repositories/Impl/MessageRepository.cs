using System.Linq;
using Latitude.DataAccess.Entities;

namespace Latitude.DataAccess.Repositories.Impl
{
    public class MessageRepository : Repository<Message, int>, IMessageRepository
    {
        public MessageRepository(ArgusDbContext context) : base(context)
        {
        }

        public override Message GetById(int id)
        {
            return _context.Messages.SingleOrDefault(x => x.Id == id);
        }
    }
}
