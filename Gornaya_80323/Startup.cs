using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gornaya_80323.Startup))]
namespace Gornaya_80323
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
