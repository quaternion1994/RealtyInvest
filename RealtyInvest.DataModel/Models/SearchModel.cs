namespace RealtyInvest.DataModel.Models
{
    public class SearchModel
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public decimal? PriceMin { get; set; }
        public decimal? PriceMax { get; set; }
    }
}
