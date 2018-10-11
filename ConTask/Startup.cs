using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConTask.Startup))]
namespace ConTask
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
