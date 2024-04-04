using Microsoft.Owin;
using music_store;
using Owin;

[assembly: OwinStartupAttribute(typeof(Startup))]

namespace music_store
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}