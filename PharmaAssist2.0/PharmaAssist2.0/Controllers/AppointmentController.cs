using PharmaAssist2._0.Models;
using PharmaAssist2._0.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PharmaAssist2._0.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: Appointment
        AppointmentRepository condex = new AppointmentRepository();
        DoctorRepository dr = new DoctorRepository();
        ConsumerRepository cm = new ConsumerRepository();

        public ActionResult DoctorAppointMent()
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Doctor"))
            {
                return RedirectToAction("Registration", "Login");
            }
            else
            {
                Doctor p = new Doctor();
                p = dr.Getuserinfo((int)Session["logged_Id"]);


                return View(condex.GetDoctorById(p.Id));
            }
        }
        public ActionResult ConsumerAppointMent()
        {
     
            Consumer a = new Consumer();
            a = cm.GetConsumerById((int)Session["logged_Id"]);


            return View(condex.GetConsumerById(a.Id));
            
        }
    }
}