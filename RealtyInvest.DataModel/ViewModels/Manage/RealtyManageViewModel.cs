using System.ComponentModel.DataAnnotations;
using RealtyInvest.DataModel.Entites;

namespace RealtyInvest.DataModel.ViewModels.Manage
{
    public class RealtyManageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Square { get; set; }
        public string Description { get; set; }
        [Display(Name="Picture URL")]
        public string PictureUrl { get; set; }
        public Coords Location { get; set; }
        public decimal Price { get; set; }
    }
}
