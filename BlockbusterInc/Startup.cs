using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlockbusterInc.Startup))]
namespace BlockbusterInc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
