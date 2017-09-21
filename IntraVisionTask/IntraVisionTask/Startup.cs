using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IntraVisionTask.Startup))]
namespace IntraVisionTask
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
