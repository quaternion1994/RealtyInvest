using System.Data.Entity;
using RealtyInvest.DataModel.Entites;

namespace RealtyInvest.DataModel
{
    public class RealtyInvestDbContext : DbContext
    {
        public RealtyInvestDbContext(): base("name=ModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    
        public virtual DbSet<RealEstate> RealEstateSet { get; set; }
        public virtual DbSet<Transaction> TransactionSet { get; set; }
        public virtual DbSet<Owner> OwnerSet { get; set; }
        public virtual DbSet<Investor> InvestorSet { get; set; }
    }
}
