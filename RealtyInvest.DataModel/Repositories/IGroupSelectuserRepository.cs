using System.Linq;
using Latitude.DataAccess.Entities;

namespace Latitude.DataAccess.Repositories
{
    public interface IGroupSelectUserRepository : IRepository<GroupSelectUser, int>
    {
        IQueryable<GroupSelectUser> GetUserGroups(int userId);
    }
}