using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CapstoneProject_EIP.Startup))]
namespace CapstoneProject_EIP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
