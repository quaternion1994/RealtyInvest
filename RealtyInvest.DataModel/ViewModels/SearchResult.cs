using RealtyInvest.DataModel.Entites;

namespace RealtyInvest.DataModel.ViewModels
{
    public class SearchResult
    {
        public int RealtyId { get; set; }
        public int RealtyName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Coords Location { get; set; }
        public string PictureUrl { get; set; }
    }
}
