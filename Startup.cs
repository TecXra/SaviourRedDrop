using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SaviourRedDrop.Startup))]
namespace SaviourRedDrop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
