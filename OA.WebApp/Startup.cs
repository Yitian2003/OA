using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OA.WebApp.Startup))]
namespace OA.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
