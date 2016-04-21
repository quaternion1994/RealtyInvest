using System.Collections.Generic;

namespace RealtyInvest.DataModel.Entites
{
    public partial class RealEstate
    {
        public RealEstate()
        {
            Transaction = new HashSet<Transaction>();
            Coordinates = new Coords();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Square { get; set; }
        public string Description { get; set; }
        public Coords Coordinates { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
