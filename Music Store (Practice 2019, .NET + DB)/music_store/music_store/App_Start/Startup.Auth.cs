using System;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace music_store
{
    public partial class Startup

    {
        public void ConfigureAuth(IAppBuilder app)

        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions

            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,

                LoginPath = new PathString("/UsersASPs/Login"),

                LogoutPath = new PathString("/UsersASPs/SingOut"),

                ExpireTimeSpan = TimeSpan.FromMinutes(5.0)
            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.MapSignalR();
        }
    }
}