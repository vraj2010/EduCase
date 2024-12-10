using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EduCase.Startup))]
namespace EduCase
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
