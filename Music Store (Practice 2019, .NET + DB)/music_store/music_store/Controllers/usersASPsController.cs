using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using music_store.Models;

namespace music_store.Controllers
{
    public class UsersASPsController : Controller
    {
        private readonly music_storeEntities4 db = new music_storeEntities4();

        private void SignInUser(string username, bool isPersistent)
        {
            var claims = new List<Claim>();
            
            try
            {
                claims.Add(new Claim(ClaimTypes.Name, username));
                
                var claimIdenties = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                var ctx = Request.GetOwinContext();

                var authenticationManager = ctx.Authentication;
                authenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent },
                    claimIdenties);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Signout()
        {
            var ctx = Request.GetOwinContext();
            
            var authenticationManager = ctx.Authentication;
            authenticationManager.SignOut();

            return RedirectToAction("Index", "Home");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "log_in, pass_word")] sellers model)
        {
            if (ModelState.IsValid)
            {
                var login = db.LoginByUsernamePassword(model.log_in, model.pass_word).ToList();
                
                if (login != null && login.Count > 0)
                {
                    var details = login.First();
                    SignInUser(details.log_in, false);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult reg([Bind(Include = "log_in, pass_word, role")] sellers user)
        {
            if (ModelState.IsValid)
            {
                var insert = db.Insert_User(user.log_in, user.pass_word, user.role).ToList();
                if (insert != null && Convert.ToInt32(insert[0]) != -1)
                {
                    db.SaveChanges();
                    return RedirectToAction("Login", "usersASPs");
                }

                ViewBag.Error = "Пользователь с таким login уже существует";
                return View();
            }
            return View();
        }

        public ActionResult reg()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}