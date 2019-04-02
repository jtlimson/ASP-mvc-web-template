using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ApplicationLayout.Startup))]
namespace ApplicationLayout
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
