using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Maxe.Client.Startup))]
namespace Maxe.Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
