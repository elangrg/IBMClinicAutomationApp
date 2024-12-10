using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IBMClinicAutomationApp.Models;

namespace IBMClinicAutomationApp.Controllers
{
    public class PurchaseOrderHeadersController : Controller
    {
        private ClinicDbEntities db = new ClinicDbEntities();

        // GET: PurchaseOrderHeaders
        public ActionResult Index()
        {
            var purchaseOrderHeaders = db.PurchaseOrderHeaders.Include(p => p.supplier);
            return View(purchaseOrderHeaders.ToList());
        }


  public ActionResult ProductLine()
        {
           
            return PartialView();
        }



        // GET: PurchaseOrderHeaders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrderHeader purchaseOrderHeader = db.PurchaseOrderHeaders.Find(id);
            if (purchaseOrderHeader == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrderHeader);
        }

        // GET: PurchaseOrderHeaders/Create
        public ActionResult Create()
        {
            ViewBag.SupplierID = new SelectList(db.suppliers, "supplierID", "name");



            return View();
        }

        // POST: PurchaseOrderHeaders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "POID,PODate,SupplierID,Note")] PurchaseOrderHeader purchaseOrderHeader)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseOrderHeaders.Add(purchaseOrderHeader);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SupplierID = new SelectList(db.suppliers, "supplierID", "name", purchaseOrderHeader.SupplierID);
            return View(purchaseOrderHeader);
        }

        // GET: PurchaseOrderHeaders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrderHeader purchaseOrderHeader = db.PurchaseOrderHeaders.Find(id);
            if (purchaseOrderHeader == null)
            {
                return HttpNotFound();
            }
            ViewBag.SupplierID = new SelectList(db.suppliers, "supplierID", "name", purchaseOrderHeader.SupplierID);
            return View(purchaseOrderHeader);
        }

        // POST: PurchaseOrderHeaders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "POID,PODate,SupplierID,Note")] PurchaseOrderHeader purchaseOrderHeader)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseOrderHeader).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SupplierID = new SelectList(db.suppliers, "supplierID", "name", purchaseOrderHeader.SupplierID);
            return View(purchaseOrderHeader);
        }

        // GET: PurchaseOrderHeaders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrderHeader purchaseOrderHeader = db.PurchaseOrderHeaders.Find(id);
            if (purchaseOrderHeader == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrderHeader);
        }

        // POST: PurchaseOrderHeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PurchaseOrderHeader purchaseOrderHeader = db.PurchaseOrderHeaders.Find(id);
            db.PurchaseOrderHeaders.Remove(purchaseOrderHeader);
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
