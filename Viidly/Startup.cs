using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Viidly.Startup))]
namespace Viidly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
