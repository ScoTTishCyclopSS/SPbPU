using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using music_store.Models;

namespace music_store.Controllers
{
    public class productsController : Controller
    {
        private readonly music_storeEntities4 db = new music_storeEntities4();

        [Authorize(Roles = "seller, admin")]

        // GET: products
        public ActionResult Index()
        {
            var products = db.products.Include(p => p.categories);
            return View(products.ToList());
        }

        // GET: products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var products = db.products.Find(id);
            if (products == null) return HttpNotFound();
            return View(products);
        }

        // GET: products/Create
        public ActionResult Create()
        {
            ViewBag.categories_id = new SelectList(db.categories, "id", "name");
            return View();
        }

        // POST: products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "id,name,count,weigh,price,description,image,categories_id")] products products,
            HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                    using (var reader = new BinaryReader(upload.InputStream))
                    {
                        products.image = reader.ReadBytes(upload.ContentLength);
                    }

                db.products.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categories_id = new SelectList(db.categories, "id", "name", products.categories_id);
            return View(products);
        }

        // GET: products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var products = db.products.Find(id);
            if (products == null) return HttpNotFound();
            ViewBag.categories_id = new SelectList(db.categories, "id", "name", products.categories_id);
            return View(products);
        }

        // POST: products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "id,name,count,weigh,price,description,image,categories_id")] products products,
            HttpPostedFileBase upload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(products).State = EntityState.Modified;
                    if (upload != null && upload.ContentLength > 0)
                    {
                        using (var reader = new BinaryReader(upload.InputStream))
                        {
                            products.image = reader.ReadBytes(upload.ContentLength);
                        }

                        db.SaveChanges();
                    }

                    else
                    {
                        db.Entry(products).Property(m => m.image).IsModified = false;
                        db.SaveChanges();
                    }

                    return RedirectToAction("Index");
                }

                return View(products);
            }
            catch (Exception e)
            {
            }

            return View();
        }

        // GET: products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var products = db.products.Find(id);
            if (products == null) return HttpNotFound();
            return View(products);
        }

        // POST: products/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var products = db.products.Find(id);
            db.products.Remove(products);
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