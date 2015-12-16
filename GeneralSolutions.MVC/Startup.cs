using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GeneralSolutions.MVC.Startup))]
namespace GeneralSolutions.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
