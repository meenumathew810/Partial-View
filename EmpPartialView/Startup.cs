using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmpPartialView.Startup))]
namespace EmpPartialView
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
