using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using music_store.Models;

namespace music_store.Controllers
{
    public class salesController : Controller
    {
        private readonly music_storeEntities4 db = new music_storeEntities4();

        [Authorize(Roles = "seller, admin")]

        // GET: sales
        public ActionResult Index()
        {
            var sales = db.sales.Include(s => s.products).Include(s => s.sellers);
            return View(sales.ToList());
        }

        // GET: sales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var sales = db.sales.Find(id);
            if (sales == null) return HttpNotFound();
            return View(sales);
        }

        // GET: sales/Create
        public ActionResult Create()
        {
            ViewBag.products_id = new SelectList(db.products, "id", "name");
            ViewBag.sellers_id = new SelectList(db.sellers, "id", "fio");
            return View();
        }

        // POST: sales/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,count,total_cost,date,sellers_id,products_id")] sales sales)
        {
            if (ModelState.IsValid)
            {
                db.sales.Add(sales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.products_id = new SelectList(db.products, "id", "name", sales.products_id);
            ViewBag.sellers_id = new SelectList(db.sellers, "id", "fio", sales.sellers_id);
            return View(sales);
        }

        // GET: sales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var sales = db.sales.Find(id);
            if (sales == null) return HttpNotFound();
            ViewBag.products_id = new SelectList(db.products, "id", "name", sales.products_id);
            ViewBag.sellers_id = new SelectList(db.sellers, "id", "fio", sales.sellers_id);
            return View(sales);
        }

        // POST: sales/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,count,total_cost,date,sellers_id,products_id")] sales sales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.products_id = new SelectList(db.products, "id", "name", sales.products_id);
            ViewBag.sellers_id = new SelectList(db.sellers, "id", "fio", sales.sellers_id);
            return View(sales);
        }

        // GET: sales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var sales = db.sales.Find(id);
            if (sales == null) return HttpNotFound();
            return View(sales);
        }

        // POST: sales/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var sales = db.sales.Find(id);
            db.sales.Remove(sales);
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