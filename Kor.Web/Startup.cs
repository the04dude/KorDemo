using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kor.Web.Startup))]
namespace Kor.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
