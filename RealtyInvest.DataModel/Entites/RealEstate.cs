using System.Collections.Generic;

namespace RealtyInvest.DataModel.Entites
{
    public sealed class RealEstate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Square { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string MainPictureUrl { get; set; }
        public Coords Location { get; set; } = new Coords();
        public RealtyInvestUser Owner { get; set; }
        public ICollection<Transaction> Transactions { get; set; } = new HashSet<Transaction>();
        public ICollection<Resource> Resources { get; set; } = new HashSet<Resource>();
    }
}
