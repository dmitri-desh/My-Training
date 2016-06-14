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
    public class ManagerController : Controller
    {
        private PurchasesAppEntities db = new PurchasesAppEntities();

        // GET: Manager
        [Authorize]
        public ActionResult Index()
        {
           return View(db.ManagerSet.ToList());
        }
        public ActionResult ManagerList()
        {
           return PartialView("PartialManagerList", Index());
        }


        // GET: Manager/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManagerSet managerSet = db.ManagerSet.Find(id);
            if (managerSet == null)
            {
                return HttpNotFound();
            }
            //return View(managerSet);
            return PartialView(managerSet);
        }

        // GET: Manager/Create
        [Authorize /*(Roles = "AdminRole", Users = "Dimon")*/]
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Manager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize /*(Roles = "AdminRole", Users = "Dimon")*/]
        public ActionResult Create([Bind(Include = "Id,SecondName")] ManagerSet managerSet)
        {
            if (ModelState.IsValid)
            {
                db.ManagerSet.Add(managerSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return PartialView(managerSet);
        }

        // GET: Manager/Edit/5
        [Authorize /*(Roles = "AdminRole", Users = "Dimon")*/]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManagerSet manager = db.ManagerSet.Find(id);
            if (manager == null)
            {
                return HttpNotFound();
            }
           // return View(manager);
            return PartialView("Edit", manager);
        }

        // POST: Manager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize /*(Roles = "AdminRole", Users = "Dimon")*/]
        public ActionResult Edit([Bind(Include = "Id,SecondName")] ManagerSet manager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

             return View(manager);
          //  return PartialView("Edit",manager);
        }

        // GET: Manager/Delete/5
        [Authorize /*(Roles = "AdminRole", Users = "Dimon")*/]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManagerSet managerSet = db.ManagerSet.Find(id);
            if (managerSet == null)
            {
                return HttpNotFound();
            }
            //return View(managerSet);
            return PartialView(managerSet);
        }

        // POST: Manager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize /*(Roles = "AdminRole", Users = "Dimon")*/]
        public ActionResult DeleteConfirmed(int id)
        {
            ManagerSet managerSet = db.ManagerSet.Find(id);
            db.ManagerSet.Remove(managerSet);
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
