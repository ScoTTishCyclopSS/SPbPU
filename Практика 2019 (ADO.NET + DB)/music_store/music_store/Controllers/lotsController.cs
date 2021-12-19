using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using music_store.Models;

namespace music_store.Controllers
{
    public class lotsController : Controller
    {
        private music_storeEntities4 db = new music_storeEntities4();
        [Authorize(Roles = "seller, admin")]

        // GET: lots
        public ActionResult Index()
        {
            var lots = db.lots.Include(l => l.products).Include(l => l.providers);
            return View(lots.ToList());
        }

        // GET: lots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lots lots = db.lots.Find(id);
            if (lots == null)
            {
                return HttpNotFound();
            }
            return View(lots);
        }

        // GET: lots/Create
        public ActionResult Create()
        {
            ViewBag.products_id = new SelectList(db.products, "id", "name");
            ViewBag.providers_id = new SelectList(db.providers, "id", "manufacturer");
            return View();
        }

        // POST: lots/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,count,cost,date,providers_id,products_id")] lots lots)
        {
            if (ModelState.IsValid)
            {
                db.lots.Add(lots);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.products_id = new SelectList(db.products, "id", "name", lots.products_id);
            ViewBag.providers_id = new SelectList(db.providers, "id", "manufacturer", lots.providers_id);
            return View(lots);
        }

        // GET: lots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lots lots = db.lots.Find(id);
            if (lots == null)
            {
                return HttpNotFound();
            }
            ViewBag.products_id = new SelectList(db.products, "id", "name", lots.products_id);
            ViewBag.providers_id = new SelectList(db.providers, "id", "manufacturer", lots.providers_id);
            return View(lots);
        }

        // POST: lots/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,count,cost,date,providers_id,products_id")] lots lots)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lots).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.products_id = new SelectList(db.products, "id", "name", lots.products_id);
            ViewBag.providers_id = new SelectList(db.providers, "id", "manufacturer", lots.providers_id);
            return View(lots);
        }

        // GET: lots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lots lots = db.lots.Find(id);
            if (lots == null)
            {
                return HttpNotFound();
            }
            return View(lots);
        }

        // POST: lots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lots lots = db.lots.Find(id);
            db.lots.Remove(lots);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
