using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NoticeBoardV3.Startup))]
namespace NoticeBoardV3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
