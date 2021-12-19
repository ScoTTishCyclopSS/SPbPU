using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using music_store.ViewModels;
using music_store.Models;

namespace music_store.Controllers
{
    public class HomeController : Controller

    {
        

        private music_storeEntities4 db = new music_storeEntities4();

        public ActionResult Index()
        {
            string result = "Вы не авторизованы";

            if (User.Identity.IsAuthenticated)

            {

                result = "Ваш логин: " + User.Identity.Name;

            }

            return View();
        }

        public ActionResult About()
        {
            IQueryable<EnrollmentDateGroup> data = from sales in db.sales
                                                   group sales by sales.date into dateGroup
                                                   select new EnrollmentDateGroup()
                                                   {
                                                       EnrollmentDate = dateGroup.Key,
                                                       salescount = dateGroup.Count()
                                                   };
            return View(data.ToList());
        }

            public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}