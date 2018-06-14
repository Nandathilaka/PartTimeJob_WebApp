using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PartTimeJob.Startup))]
namespace PartTimeJob
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
