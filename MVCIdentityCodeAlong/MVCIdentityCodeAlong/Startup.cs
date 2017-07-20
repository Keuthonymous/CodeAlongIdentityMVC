using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCIdentityCodeAlong.Startup))]
namespace MVCIdentityCodeAlong
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
