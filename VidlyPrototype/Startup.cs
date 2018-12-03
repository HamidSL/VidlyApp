using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidlyPrototype.Startup))]
namespace VidlyPrototype
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
