using System.Linq;
using Latitude.DataAccess.Entities;

namespace Latitude.DataAccess.Repositories.Impl
{
    public class ClientDetailRepository : Repository<ClientDetail, int>, IClientDetailRepository
    {
        public ClientDetailRepository(ArgusDbContext context) : base(context)
        {
        }

        public override ClientDetail GetById(int id)
        {
            return _context.ClientDetails.SingleOrDefault(x => x.Id == id);
        }
    }
}
