using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using PagedList;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        private PurchasesAppEntities db = new PurchasesAppEntities();

        // GET: Product
        [Authorize]
        public ActionResult Index(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(db.ProductSet.ToPagedList(pageNumber, pageSize));
            //return View(db.ProductSet.ToList());
        }

        // GET: Product/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSet productSet = db.ProductSet.Find(id);
            if (productSet == null)
            {
                return HttpNotFound();
            }
            return View(productSet);
        }

        // GET: Product/Create
        [Authorize(Roles = "AdminRole")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminRole")]
        public ActionResult Create([Bind(Include = "Id,Name")] ProductSet productSet)
        {
            if (ModelState.IsValid)
            {
                db.ProductSet.Add(productSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productSet);
        }

        // GET: Product/Edit/5
        [Authorize(Roles = "AdminRole")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSet productSet = db.ProductSet.Find(id);
            if (productSet == null)
            {
                return HttpNotFound();
            }
            return View(productSet);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminRole")]
        public ActionResult Edit([Bind(Include = "Id,Name")] ProductSet productSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productSet);
        }

        // GET: Product/Delete/5
        [Authorize(Roles = "AdminRole")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSet productSet = db.ProductSet.Find(id);
            if (productSet == null)
            {
                return HttpNotFound();
            }
            return View(productSet);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminRole")]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductSet productSet = db.ProductSet.Find(id);
            db.ProductSet.Remove(productSet);
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
