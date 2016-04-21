using System.Linq;
using Latitude.DataAccess.Entities;

namespace Latitude.DataAccess.Repositories.Impl
{
    public class ClientRepository : Repository<Client, int>, IClientRepository
    {
        public ClientRepository(ArgusDbContext context) : base(context)
        {
        }

        public override Client GetById(int id)
        {
            return _context.Clients.SingleOrDefault(x => x.Id == id);
        }

        public Client GetByEmail(string email)
        {
            return _context.Clients.FirstOrDefault(p => p.Email == email);
        }
    }
}
