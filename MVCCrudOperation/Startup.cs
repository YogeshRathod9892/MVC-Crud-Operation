using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCCrudOperation.Startup))]
namespace MVCCrudOperation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
