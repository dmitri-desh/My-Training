using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace WebApp.Controllers
{
    public class OrdersController : Controller
    {
        private PurchasesAppEntities db = new PurchasesAppEntities();

        // GET: Orders
        public ActionResult Index()
        {
            var orderSet = db.OrderSet.Include(o => o.CustomerSet).Include(o => o.ManagerSet).Include(o => o.ProductSet);
            return View(orderSet.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderSet orderSet = db.OrderSet.Find(id);
            if (orderSet == null)
            {
                return HttpNotFound();
            }
            return View(orderSet);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.CustomerSet, "Id", "SecondName");
            ViewBag.ManagerId = new SelectList(db.ManagerSet, "Id", "SecondName");
            ViewBag.ProductId = new SelectList(db.ProductSet, "Id", "Name");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PurchaseDate,Amount,ManagerId,CustomerId,ProductId")] OrderSet orderSet)
        {
            if (ModelState.IsValid)
            {
                db.OrderSet.Add(orderSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.CustomerSet, "Id", "SecondName", orderSet.CustomerId);
            ViewBag.ManagerId = new SelectList(db.ManagerSet, "Id", "SecondName", orderSet.ManagerId);
            ViewBag.ProductId = new SelectList(db.ProductSet, "Id", "Name", orderSet.ProductId);
            return View(orderSet);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderSet orderSet = db.OrderSet.Find(id);
            if (orderSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.CustomerSet, "Id", "SecondName", orderSet.CustomerId);
            ViewBag.ManagerId = new SelectList(db.ManagerSet, "Id", "SecondName", orderSet.ManagerId);
            ViewBag.ProductId = new SelectList(db.ProductSet, "Id", "Name", orderSet.ProductId);
            return View(orderSet);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PurchaseDate,Amount,ManagerId,CustomerId,ProductId")] OrderSet orderSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.CustomerSet, "Id", "SecondName", orderSet.CustomerId);
            ViewBag.ManagerId = new SelectList(db.ManagerSet, "Id", "SecondName", orderSet.ManagerId);
            ViewBag.ProductId = new SelectList(db.ProductSet, "Id", "Name", orderSet.ProductId);
            return View(orderSet);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderSet orderSet = db.OrderSet.Find(id);
            if (orderSet == null)
            {
                return HttpNotFound();
            }
            return View(orderSet);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderSet orderSet = db.OrderSet.Find(id);
            db.OrderSet.Remove(orderSet);
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
