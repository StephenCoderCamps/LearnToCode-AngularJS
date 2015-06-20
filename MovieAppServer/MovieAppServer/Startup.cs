using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieAppServer.Startup))]
namespace MovieAppServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
