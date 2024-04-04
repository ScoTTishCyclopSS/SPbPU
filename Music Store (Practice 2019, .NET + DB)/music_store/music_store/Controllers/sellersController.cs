using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using music_store.Models;

namespace music_store.Controllers
{
    public class sellersController : Controller
    {
        private readonly music_storeEntities4 db = new music_storeEntities4();

        [Authorize(Roles = "admin")]
        // GET: sellers
        public ViewResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "fio_desc" : "";
            ViewBag.PassSortParm = sortOrder == "passport" ? "passport_desc" : "passport";
            
            var sellers = from s in db.sellers select s;
            
            if (!string.IsNullOrEmpty(searchString)) sellers = sellers.Where(s => s.fio.Contains(searchString));
            switch (sortOrder)
            {
                case "fio_desc":
                    sellers = sellers.OrderByDescending(s => s.fio); 
                    break;
                case "passport":

                    sellers = sellers.OrderBy(s => s.passport_info);
                    break;
                case "passport_desc":
                    sellers = sellers.OrderByDescending(s => s.passport_info);
                    break;
                default:
                    sellers = sellers.OrderBy(s => s.fio);
                    break;
            }

            return View(sellers.ToList());
        }

        // GET: sellers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var sellers = db.sellers.Find(id);
            if (sellers == null) return HttpNotFound();
            return View(sellers);
        }

        // GET: sellers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: sellers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fio,passport_info,log_in,pass_word,role")] sellers sellers)
        {
            var test = db.sellers.FirstOrDefault(x =>
                x.fio.Equals(sellers.fio) || x.passport_info.Equals(sellers.passport_info));

            if (test == null)
            {
                if (ModelState.IsValid)
                {
                    db.sellers.Add(sellers);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(sellers);
        }

        // GET: sellers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            var sellers = db.sellers.Find(id);
            if (sellers == null) return HttpNotFound();
            
            return View(sellers);
        }

        // POST: sellers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fio,passport_info")] sellers sellers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sellers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sellers);
        }

        // GET: sellers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            var sellers = db.sellers.Find(id);
            if (sellers == null) return HttpNotFound();
            
            return View(sellers);
        }

        // POST: sellers/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var sellers = db.sellers.Find(id);
            db.sellers.Remove(sellers);
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}