using Latitude.Common.DependencyInjection.Models;
using Latitude.DataAccess.Entities;

namespace Latitude.DataAccess.Repositories
{
    public interface IClientRepository : IRepository<Client, int>, IDependency
    {
        Client GetByEmail(string email);
    }
}