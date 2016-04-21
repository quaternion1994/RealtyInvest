using Latitude.Common.DependencyInjection.Models;
using Latitude.DataAccess.Entities;

namespace Latitude.DataAccess.Repositories
{
    public interface IUserRepository : IRepository<User, int>, IDependency
    {
        User GetByEmail(string email);
    }
}