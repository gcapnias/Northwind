using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Northwind.Website.Startup))]
namespace Northwind.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
