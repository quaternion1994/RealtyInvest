using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RealtyInvest.DataModel.Entites
{
    public class RealtyInvestUser : IdentityUser
    {
        public RealtyInvestUser()
        {

        }
        public virtual ICollection<RealEstate> RealEstate { get; set; } = new HashSet<RealEstate>();
        public virtual ICollection<Transaction> Transaction { get; set; } = new HashSet<Transaction>();
    }
}