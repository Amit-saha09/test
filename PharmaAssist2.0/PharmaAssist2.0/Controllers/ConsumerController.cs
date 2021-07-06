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
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Consumer"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {

                return View();
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Consumer"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Create(Consumer c)
        {
            


            string filename = Path.GetFileNameWithoutExtension(c.Imagefile.FileName);
            string extention = Path.GetExtension(c.Imagefile.FileName);
            filename = filename + DateTime.Now.ToString("yyssmmfff") + extention;
            c.Image = "~/Image/" + filename;
            filename = Path.Combine(Server.MapPath("~/Image/"), filename);
            c.Imagefile.SaveAs(filename);


            var x = context.GetConsumerById(Session["logged_id"].GetHashCode());
            c.LoginId = x.Id;
            return View(c);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Consumer"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {

                context.GetAll();
                return View(context.Get(id));
            }
        }
        [HttpPost]
        public ActionResult Edit(Consumer c)
        {
            //Session["logged_id"] = 1;

            string filename = Path.GetFileNameWithoutExtension(c.Imagefile.FileName);
            string extention = Path.GetExtension(c.Imagefile.FileName);
            filename = filename + DateTime.Now.ToString("yyssmmfff") + extention;
            c.Image = "~/Image/" + filename;
            filename = Path.Combine(Server.MapPath("~/Image/"), filename);
            c.Imagefile.SaveAs(filename);

            var x = context.GetConsumerById(Session["logged_id"].GetHashCode());
            c.LoginId = x.Id;

            context.Update(c);
            return RedirectToAction("Index");
        }

        public ActionResult FindDoctor()
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Consumer"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var finddoctor = acontext.GetAll();
                return View(finddoctor);
            }
        }
        [HttpGet]
        public ActionResult ProblemPost()
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Consumer"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {

                ConsumerRepository PPRepo = new ConsumerRepository();
                ViewData["problemposts"] = PPRepo.GetAll();

                ProblemPost dm = new ProblemPost();

                return View();
            }

        }
        [HttpPost]
        public ActionResult ProblemPost(ProblemPost p)
        {
            

            ProblemPost pp = new ProblemPost();

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

        public ActionResult MyAppointments()
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Consumer"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var finddoctor = ccontext.GetAll();
                return View(finddoctor);
            }
        }


        [HttpGet]
        public ActionResult Appointment()
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Consumer"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {

                SlotRepository sl = new SlotRepository();
                DoctorRepository dc = new DoctorRepository();

                ViewData["slots"] = sl.GetAll();
                ViewData["doctors"] = dc.GetAll();

                return View();
            }
        }

        [HttpPost]
        public ActionResult Appointment(Appointment ap, int id)
        {

            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Consumer"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {

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
}