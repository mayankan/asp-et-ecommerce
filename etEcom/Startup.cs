using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(etEcom.Startup))]
namespace etEcom
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
