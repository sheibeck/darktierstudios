using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(darktierstudios.Startup))]
namespace darktierstudios
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
