using System.Web.Mvc;

namespace RealtyInvest.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                null,
                "admin/{controller}/{action}/{id}",
                new { action = "Index", controller = "Main", id = 0 },
                new string[] {
                 "RealtyInvest.Core.Controllers",
                 "RealtyInvest.Core.Areas.Admin.Controllers"
                }
);
        }
    }
}