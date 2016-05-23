using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Productoras.Startup))]
namespace Productoras
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
