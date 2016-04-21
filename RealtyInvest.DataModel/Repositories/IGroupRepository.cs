using System.Linq;
using Latitude.DataAccess.Entities;

namespace Latitude.DataAccess.Repositories
{
    public interface IGroupRepository : IRepository<Group, int>
    {
        IQueryable<Group> GetGroupsForClient(int clientId);
    }
}