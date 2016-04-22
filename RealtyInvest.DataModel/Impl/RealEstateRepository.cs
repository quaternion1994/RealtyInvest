using RealtyInvest.DataModel.Entites;
using RealtyInvest.DataModel.Repositories;
using System.Linq;

namespace RealtyInvest.DataModel.Impl
{
    public class RealEstateRepository : Repository<RealEstate, int>, IRealEstateRepository
    {
        public RealEstateRepository(RealtyInvestDbContext contextDb) : base(contextDb)
        {
        }
        public override RealEstate GetById(int id) => ContextDb.RealEstateSet.First(x=>x.Id == id);
    }
}
