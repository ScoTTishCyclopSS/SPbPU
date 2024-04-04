using System.Linq;
using System.Web.Mvc;
using music_store.Models;
using music_store.ViewModels;

namespace music_store.Controllers
{
    public class HomeController : Controller
    {
        private readonly music_storeEntities4 db = new music_storeEntities4();

        public ActionResult Index()
        {
            var result = "Вы не авторизованы";
            
            if (User.Identity.IsAuthenticated) result = "Ваш логин: " + User.Identity.Name;

            return View();
        }

        public ActionResult About()
        {
            var data = from sales in db.sales
                group sales by sales.date
                into dateGroup
                select new EnrollmentDateGroup
                {
                    EnrollmentDate = dateGroup.Key,
                    salescount = dateGroup.Count()
                };
            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            // return View();
            return Index();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}