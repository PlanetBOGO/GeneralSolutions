using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GeneralSolutions.WCF.Startup))]
namespace GeneralSolutions.WCF
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
