using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(RealtyInvest.Web.Startup))]

namespace RealtyInvest.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
