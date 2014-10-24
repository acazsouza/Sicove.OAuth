using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(App1.Startup))]
namespace App1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
