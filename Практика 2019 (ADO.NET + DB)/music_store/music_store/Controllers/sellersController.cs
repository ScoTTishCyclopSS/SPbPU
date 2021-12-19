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
    public class sellersController : Controller
    {
        private music_storeEntities4 db = new music_storeEntities4();
        [Authorize(Roles = "admin")]
        // GET: sellers
        public ViewResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "fio_desc" : "";
            ViewBag.PassSortParm = sortOrder == "passport" ? "passport_desc" : "passport";
            var sellers = from s in db.sellers
                           select s;
            if (!String.IsNullOrEmpty(searchString))

            {

                sellers = sellers.Where(s => s.fio.Contains(searchString));

            }
            switch (sortOrder)
            {
                case "fio_desc":
                    sellers = sellers.OrderByDescending(s => s.fio); //сортировка по убыванию
                    break;
                case "passport": //сортировка по убыванию
                    
                    sellers = sellers.OrderBy(s => s.passport_info);              
                    break;
                case "passport_desc": //сортировка по возрастанию
                    sellers = sellers.OrderByDescending(s => s.passport_info);
                    break;
                default: //сортировка по возрастанию
                    sellers = sellers.OrderBy(s => s.fio);
                    break;
            }
            return View(sellers.ToList());
        }

        // GET: sellers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sellers sellers = db.sellers.Find(id);
            if (sellers == null)
            {
                return HttpNotFound();
            }
            return View(sellers);
        }

        // GET: sellers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: sellers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fio,passport_info,log_in,pass_word,role")] sellers sellers)
        {
            var test = db.sellers.FirstOrDefault(x => x.fio.Equals(sellers.fio) || x.passport_info.Equals(sellers.passport_info));
            if(test == null)
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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sellers sellers = db.sellers.Find(id);
            if (sellers == null)
            {
                return HttpNotFound();
            }
            return View(sellers);
        }

        // POST: sellers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sellers sellers = db.sellers.Find(id);
            if (sellers == null)
            {
                return HttpNotFound();
            }
            return View(sellers);
        }

        // POST: sellers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sellers sellers = db.sellers.Find(id);
            db.sellers.Remove(sellers);
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
