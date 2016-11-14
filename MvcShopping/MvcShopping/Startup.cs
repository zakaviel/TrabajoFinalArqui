using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcShopping.Startup))]
namespace MvcShopping
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
