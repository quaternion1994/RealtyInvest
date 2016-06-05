using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using RealtyInvest.DataModel.Entites;
using System.Configuration;
using System.Linq;
using Microsoft.AspNet.Identity;
using System;

namespace RealtyInvest.DataModel
{
    public class RealtyInvestDbContext : IdentityDbContext<RealtyInvestUser>
    {
        public RealtyInvestDbContext(): base("DefaultConnection")
        {
            Database.SetInitializer(new RealtyInvestInitializer());
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    
        public virtual DbSet<RealEstate> RealEstateSet { get; set; }
        public virtual DbSet<Transaction> TransactionSet { get; set; }
    }

    public class RealtyInvestInitializer :  DropCreateDatabaseIfModelChanges<RealtyInvestDbContext>
    {
        const string Investor = "Investor";
        const string Owner = "Owner";
        protected override void Seed(RealtyInvestDbContext context)
        {
            var userManager = new UserManager<RealtyInvestUser>(new UserStore<RealtyInvestUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            userManager.Create(new RealtyInvestUser
            {
                UserName = "vlad"
            }, "qwerty123");

            try
            {
                if (!roleManager.RoleExists(Investor))
                    roleManager.Create(new IdentityRole { Name = Investor });
                if (!roleManager.RoleExists(Owner))
                    roleManager.Create(new IdentityRole { Name = Owner });

                string[] owners = ConfigurationManager.AppSettings["Owners"].Split(',');
                foreach (var owner in owners)
                {
                    var user = userManager.FindByName(owner);
                    if (!userManager.IsInRole(user.Id, Owner))
                        userManager.AddToRole(user.Id, Owner);
                }
            }
            finally
            {
                userManager.Dispose();
                roleManager.Dispose();
                base.Seed(context);
            }
        }
    }

}
