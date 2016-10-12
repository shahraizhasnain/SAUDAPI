using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SaudaWebApp.Startup))]
namespace SaudaWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
