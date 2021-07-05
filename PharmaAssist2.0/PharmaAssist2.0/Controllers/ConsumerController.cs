using PharmaAssist2._0.Models;
using PharmaAssist2._0.Models.ModelView;
using PharmaAssist2._0.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PharmaAssist2._0.Controllers
{
    public class ConsumerController : Controller
    {
        ConsumerRepository context = new ConsumerRepository();
        ProblemPostRepository bcontext = new ProblemPostRepository();
        DoctorRepository acontext = new DoctorRepository();
        AppointmentRepository ccontext = new AppointmentRepository();
        // GET: Consumer
        public ActionResult Index()
        {
       
            return View();
        }

        public ActionResult FindDoctor()
        {
            var finddoctor = acontext.GetAll();
            return View(finddoctor);
        }
        [HttpGet]
        public ActionResult ProblemPost()
        {

            /*ConsumerRepository PPRepo = new ConsumerRepository();
            ViewData["problemposts"] = PPRepo.GetAll();*/

            ProblemPost dm = new ProblemPost();

            return View();
          
        }
        [HttpPost]
        public ActionResult ProblemPost(ProblemPost p)
        {
            Session["logged_email"] = "john@gmail.com";

           /* ProblemPost pp = new ProblemPost();*/

            string filename = Path.GetFileNameWithoutExtension(p.Imagefile.FileName);
            string extention = Path.GetExtension(p.Imagefile.FileName);
            filename = filename + DateTime.Now.ToString("yyssmmfff") + extention;
            p.Image = "~/Image/" + filename;
            filename = Path.Combine(Server.MapPath("~/Image/"), filename);
            p.Imagefile.SaveAs(filename);

            ConsumerRepository PPRepo = new ConsumerRepository();
            var x = PPRepo.GetConsumerByEmail(Session["logged_email"].ToString());
            p.ConsumerId = x.Id;
            bcontext.Insert(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Appointment()
        {
            SlotRepository sl = new SlotRepository();
            DoctorRepository dc = new DoctorRepository();

            ViewData["slots"] = sl.GetAll();
            ViewData["doctors"] = dc.GetAll();


            return View();
        }

        [HttpPost]
        public ActionResult Appointment(Appointment ap, int id)
        {
            
            Session["logged_id"] = 1;
           
            AppointmentRepository APRepo = new AppointmentRepository();
            ConsumerRepository PPRepo = new ConsumerRepository();
            var x = PPRepo.GetConsumerById(Session["logged_id"].GetHashCode());
            ap.ConsumerId = x.Id;
            var y = acontext.Get(id);
            ap.DoctorId = y.Id;
            ccontext.Insert(ap);
            return RedirectToAction("Index");
        }

    }
}