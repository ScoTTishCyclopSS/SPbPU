using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using music_store.Models;

namespace music_store.Controllers
{
    public class providersController : Controller
    {
        private readonly music_storeEntities4 db = new music_storeEntities4();

        [Authorize(Roles = "seller, admin")]

        // GET: providers
        public ActionResult Index()
        {
            return View(db.providers.ToList());
        }

        // GET: providers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var providers = db.providers.Find(id);
            if (providers == null) return HttpNotFound();
            return View(providers);
        }

        // GET: providers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: providers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,manufacturer,address,email,tel_number")] providers providers)
        {
            if (ModelState.IsValid)
            {
                db.providers.Add(providers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(providers);
        }

        // GET: providers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            var providers = db.providers.Find(id);
            if (providers == null) return HttpNotFound();
            
            return View(providers);
        }

        // POST: providers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,manufacturer,address,email,tel_number")] providers providers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(providers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(providers);
        }

        // GET: providers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            var providers = db.providers.Find(id);
            if (providers == null) return HttpNotFound();
            
            return View(providers);
        }

        // POST: providers/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var providers = db.providers.Find(id);
            
            db.providers.Remove(providers);
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