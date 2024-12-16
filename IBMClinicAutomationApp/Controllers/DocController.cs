using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IBMClinicAutomationApp.Controllers
{

   // [HandleError(ExceptionType =  typeof(FormatException) ,View = "FormatExcView")]
    public class DocController : Controller
    {  Models.ClinicDbEntities _db = new Models.ClinicDbEntities();
        // GET: Doc


        protected override void OnException(ExceptionContext filterContext)
        {


        ViewResult vr = new ViewResult();

            vr.ViewBag.Exception = filterContext.Exception;

            vr.ViewName = "ExcForDeveloperView";



           filterContext.Result = vr;
            
        }

        public ActionResult ViewAppointments()
        {


            int i = int.Parse("abc");



            // From Session["CurrentUser"]
          int phyid = 1;
          
          var rst=  _db.Appointments.Include("patient") .Where(a=>a.PhysicianID==phyid && a.Status.ToLower()=="confirmed");

           
            return View(rst.ToList());
        }

 public ActionResult CreateAdvice(int id)
        {

           


            var apt = _db.Appointments.Find(id);

            ViewBag.Drugs = _db.drugs.ToList();


            ViewBag.AppointmentID = id.ToString();
            ViewBag.PatientID = apt.PatientID.ToString();
            ViewBag.PatientName = apt.patient.name;


            var adv = new Models.advice();
            adv.prescriptions.Add(new Models.prescription());

            return View(adv);
        }

        [HttpPost]
        public ActionResult CreateAdvice(Models.advice adv, int? PatientID,int? AppointmentID)
        {


            if (ModelState.IsValid) {


                Models.ClinicDbEntities _db = new Models.ClinicDbEntities();


                adv.Appointment = _db.Appointments.Find(AppointmentID);
                foreach (var prs in adv.prescriptions)
                {
                    prs.drug = _db.drugs.Find(prs.drugID);

                }

                _db.advices.Add(adv);
                _db.SaveChanges();

                return RedirectToAction("ViewAppointments");
            }
            ViewBag.Drugs = _db.drugs.ToList();
            return View(adv);

        }


        public ActionResult CreatePrescriptionLine(string id)
        {
            ViewBag.slno = id;
            return PartialView();
        }




    }
}