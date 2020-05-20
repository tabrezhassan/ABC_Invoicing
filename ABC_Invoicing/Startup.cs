using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ABC_Invoicing.Startup))]
namespace ABC_Invoicing
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
