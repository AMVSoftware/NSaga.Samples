using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCSample.Startup))]
namespace MVCSample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureInjector(app);
            ConfigureAuth(app);
        }
    }
}
