using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ValidationDemo.Startup))]
namespace ValidationDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
