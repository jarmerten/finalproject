using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GrindStone.Startup))]
namespace GrindStone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
