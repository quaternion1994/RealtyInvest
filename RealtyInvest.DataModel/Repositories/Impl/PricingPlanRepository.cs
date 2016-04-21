using System.Linq;
using Latitude.DataAccess.Entities;

namespace Latitude.DataAccess.Repositories.Impl
{
    public class PricingPlanRepository : Repository<PricingPlan, int>, IPricingPlanRepository
    {
        public PricingPlanRepository(ArgusDbContext context) : base(context)
        {
        }

        public override PricingPlan GetById(int id)
        {
            return _context.PricingPlans.SingleOrDefault(x => x.Id == id);
        }
    }
}
