using System;

using Microsoft.AspNet.Identity;

using Microsoft.AspNet.Identity.Owin;

using Microsoft.Owin;

using Microsoft.AspNet.SignalR;

using Microsoft.Owin.Security.Cookies;

using Owin;

using music_store.Models;



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