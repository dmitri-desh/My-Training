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
        [Authorize]
        public ActionResult Index()
        {
            var orderSet = db.OrderSet.Include(o => o.CustomerSet).Include(o => o.ManagerSet).Include(o => o.ProductSet);
            return View(orderSet.ToList());
        }

        // GET: Orders/Details/5
        [Authorize]
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

        public ActionResult OrderList (DateTime from, DateTime to, double managerId, double customerId, double productId)
        {
            var item = new OrdersWithFilters().GetOrders(from, to, managerId, customerId, productId)
                                              .Select(x => new OrderSet() { Id = x.Id, Amount = x.Amount, PurchaseDate = x.PurchaseDate,
                                                                            CustomerId = x.CustomerId, ManagerId = x.ManagerId, ProductId = x.ProductId });
            return PartialView("OrderList",item);
        }


        // GET: Orders/Create
        [Authorize /*(Roles = "AdminRole")*/]
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
        [Authorize /*(Roles = "AdminRole")*/]
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
        [Authorize /*(Roles = "AdminRole")*/]
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
        [Authorize /*(Roles = "AdminRole")*/]
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
        [Authorize /*(Roles = "AdminRole")*/]
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
        [Authorize /*(Roles = "AdminRole")*/]
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
