using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using RealtyInvest.DataModel.Entites;

namespace RealtyInvest.DataModel
{
    public class RealtyInvestDbContext : IdentityDbContext<RealtyInvestUser>
    {
        public RealtyInvestDbContext(): base("DefaultConnection")
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
