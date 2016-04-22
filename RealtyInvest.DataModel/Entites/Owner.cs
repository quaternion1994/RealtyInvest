using System.Collections.Generic;

namespace RealtyInvest.DataModel.Entites
{
    public partial class Owner : Person
    {
        public int Id { get; set; }

        public virtual ICollection<RealEstate> RealEstate { get; set; } = new HashSet<RealEstate>();
    }
}
