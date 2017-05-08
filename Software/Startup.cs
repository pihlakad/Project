using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Software.Startup))]
namespace Software
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
