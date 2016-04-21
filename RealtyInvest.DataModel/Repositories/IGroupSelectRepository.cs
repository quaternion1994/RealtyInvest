using System.Linq;
using Latitude.DataAccess.Entities;

namespace Latitude.DataAccess.Repositories
{
    public interface IGroupSelectRepository : IRepository<GroupSelect, int>
    {
        IQueryable<GroupSelect> GetVehiclesByGroupAndClientId(int clientId, int groupId);
    }
}