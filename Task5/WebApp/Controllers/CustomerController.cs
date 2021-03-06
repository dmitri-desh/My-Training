﻿using System;
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
    public class CustomerController : Controller
    {
        private PurchasesAppEntities db = new PurchasesAppEntities();

        // GET: Customer
        [Authorize]
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(db.CustomerSet.OrderBy(x => x.Id).ToPagedList(pageNumber, pageSize));
          //  return View(db.CustomerSet.ToList());
        }

        // GET: Customer/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerSet customerSet = db.CustomerSet.Find(id);
            if (customerSet == null)
            {
                return HttpNotFound();
            }
            return View(customerSet);
        }

        // GET: Customer/Create
        [Authorize /*(Roles = "AdminRole")*/]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize /*(Roles = "AdminRole")*/]
        public ActionResult Create([Bind(Include = "Id,SecondName")] CustomerSet customerSet)
        {
            if (ModelState.IsValid)
            {
                db.CustomerSet.Add(customerSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerSet);
        }

        // GET: Customer/Edit/5
        [Authorize /*(Roles = "AdminRole")*/]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerSet customerSet = db.CustomerSet.Find(id);
            if (customerSet == null)
            {
                return HttpNotFound();
            }
            return View(customerSet);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize /*(Roles = "AdminRole")*/]
        public ActionResult Edit([Bind(Include = "Id,SecondName")] CustomerSet customerSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerSet);
        }

        // GET: Customer/Delete/5
        [Authorize /*(Roles = "AdminRole")*/]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerSet customerSet = db.CustomerSet.Find(id);
            if (customerSet == null)
            {
                return HttpNotFound();
            }
            return View(customerSet);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize /*(Roles = "AdminRole")*/]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerSet customerSet = db.CustomerSet.Find(id);
            db.CustomerSet.Remove(customerSet);
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
