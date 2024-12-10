using IBMClinicAutomationApp.Models;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IBMClinicAutomationApp.Controllers
{
    public class ChemistController : Controller
    {
        private ClinicDbEntities db = new ClinicDbEntities();

        // GET: Chemist
        public ActionResult CreatePO()
        {
            ViewBag.SupplierID = new SelectList(db.suppliers, "supplierID", "name");


            ViewBag.Drugs = db.drugs.ToList();



            PurchaseOrderHeader header = new PurchaseOrderHeader();
            header.PODate = DateTime.Now;

            header.PurchaseOrderDrugLines.Add(new PurchaseOrderDrugLine());


            return View(header);
        }
        [HttpPost]
        public ActionResult CreatePO(Models.PurchaseOrderHeader POHeader)
        {

            POHeader.supplier = db.suppliers.Find(POHeader.SupplierID);


            foreach (var DrgLn in POHeader.PurchaseOrderDrugLines)
            {
                DrgLn.drug = db.drugs.Find(DrgLn.DrugID);

            }

            db.PurchaseOrderHeaders.Add(POHeader);
            db.SaveChanges();

            ViewBag.SupplierID = new SelectList(db.suppliers, "supplierID", "name");


            ViewBag.Drugs = db.drugs.ToList();
            PurchaseOrderHeader header = new PurchaseOrderHeader();
            header.PODate = DateTime.Now;

            header.PurchaseOrderDrugLines.Add(new PurchaseOrderDrugLine());
            return View(header);
        }

        public ActionResult CreateProductLine(string id )
        {
            ViewBag.slno = id;
            return PartialView();
        }



    }
}