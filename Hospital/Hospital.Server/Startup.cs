using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hospital.Server.Startup))]
namespace Hospital.Server
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
