using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EquineElegance.WebApp.Startup))]
namespace EquineElegance.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
