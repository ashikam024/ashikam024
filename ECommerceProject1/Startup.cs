using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ECommerceProject1.Startup))]
namespace ECommerceProject1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
