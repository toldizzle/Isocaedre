using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClubRP.Startup))]

namespace ClubRP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}