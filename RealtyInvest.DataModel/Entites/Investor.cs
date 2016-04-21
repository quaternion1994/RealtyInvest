using System.Collections.Generic;
using RealtyInvest.DataModel;

namespace RealtyInvest.DataModel.Entites
{
    public partial class Investor
    {
        public Investor()
        {
            Transaction = new HashSet<Transaction>();
        }
    
        public int Id { get; set; }
        public string UserName { get; set; }
    
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
