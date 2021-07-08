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

            
                Doctor p = new Doctor();
                p = dr.Getuserinfo((int)Session["logged_Id"]);


                return View(condex.GetDoctorById(p.Id));
            
        }
        public ActionResult ConsumerAppointMent()
        {

            
                Consumer p = new Consumer();

                p = cm.GetConsumerById((int)Session["logged_id"]);



                return View(condex.GetConsumerById(p.Id));
            

        }
    }
}