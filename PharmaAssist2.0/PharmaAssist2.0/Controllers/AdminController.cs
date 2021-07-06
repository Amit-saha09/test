using PharmaAssist2._0.Repository;
using PharmaAssist2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
using PharmaAssist2._0.Models.ModelView;

namespace PharmaAssist2._0.Controllers
{
    public class AdminController : Controller
    {
        AdminRepository contex = new AdminRepository();
        // GET: Admin
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult AdminsManagement()
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                AdminRepository ar = new AdminRepository();
                var admins = ar.GetAll();
                return View(admins);
            }
        }

        [HttpGet]
        public ActionResult ApproveLoginAdmin(int id)
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                LoginRepository lr = new LoginRepository();
                lr.UpdateLoginStatus(id, 1);
                return RedirectToAction("AdminsManagement");
            }
        }

        [HttpGet]
        public ActionResult RejectLoginAdmin(int id)
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                LoginRepository lr = new LoginRepository();
                lr.UpdateLoginStatus(id, 2);
                return RedirectToAction("AdminsManagement");
            }
        }

        [HttpGet]
        public ActionResult GetAdminsByName(string id)
        {
            AdminRepository ar = new AdminRepository();
            var admins = ar.GetAdminsByName(id);
            return this.Json(admins, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AdminCreate()
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                Admin p = new Admin();
                return View(p);
            }

        }

        [HttpPost]
        public ActionResult AdminCreate(Admin a, string Password, string Email)
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                string filename = Path.GetFileNameWithoutExtension(a.Imagefile.FileName);
                string extention = Path.GetExtension(a.Imagefile.FileName);
                filename = filename + DateTime.Now.ToString("yyssmmfff") + extention;
                a.Image = "~/Image/" + filename;
                filename = Path.Combine(Server.MapPath("~/Image/"), filename);
                a.Imagefile.SaveAs(filename);

                var log = new LoginRepository();
                Login lo = new Login();

                lo.Email = Email;
                lo.Password = Password;
                lo.Type = "Admin";
                lo.RegistrationStatus = 1;
                lo.LoginStatus = 1;

                log.Insert(lo);

                lo = log.Getthat(Email.ToString());
                a.LoginId = lo.Id;

                //dm.Email = Session["regemail"].ToString();
                contex.Insert(a);
                return RedirectToAction("AdminsManagement");
            }
        }


        [HttpGet]
        public ActionResult AdminUpdate(int id)
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                AdminRepository ar = new AdminRepository();

                Admin p;

                p = ar.GetAdmin(id);

                if (p != null)
                {
                    return View(p);
                }
                else
                {
                    return RedirectToAction("AdminsManagement");
                }
            }
        }

        [HttpPost]
        public ActionResult AdminUpdate(Admin a)
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                AdminRepository ar = new AdminRepository();

                ar.Update(a);

                return RedirectToAction("AdminsManagement");
            }
        }


        [HttpGet]
        public ActionResult ManagersManagement()
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ManagerRepository mr = new ManagerRepository();
                var managers = mr.GetAll();
                return View(managers);
            }
        }

        [HttpGet]
        public ActionResult ApproveLoginManager(int id)
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                LoginRepository lm = new LoginRepository();
                lm.UpdateLoginStatus(id, 1);
                return RedirectToAction("ManagersManagement");
            }
        }

        [HttpGet]
        public ActionResult RejectLoginManager(int id)
        {

            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                LoginRepository lm = new LoginRepository();
                lm.UpdateLoginStatus(id, 2);
                return RedirectToAction("ManagersManagement");
            }
        }

        [HttpGet]
        public ActionResult ManagerCreate()
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                Manager p = new Manager();
                return View(p);
            }

        }

        [HttpPost]
        public ActionResult ManagerCreate(Manager a)
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                string filename = Path.GetFileNameWithoutExtension(a.Imagefile.FileName);
                string extention = Path.GetExtension(a.Imagefile.FileName);
                filename = filename + DateTime.Now.ToString("yyssmmfff") + extention;
                a.Image = "~/Image/" + filename;
                filename = Path.Combine(Server.MapPath("~/Image/"), filename);
                a.Imagefile.SaveAs(filename);

                var log = new LoginRepository();
                Login lo = new Login();

                lo.Email = a.Email.ToString();
                lo.Password = a.Password.ToString();
                lo.Type = "Manager";
                lo.RegistrationStatus = 1;
                lo.LoginStatus = 1;

                log.Insert(lo);

                lo = log.Getthat(a.Email.ToString());
                a.LoginId = lo.Id;

                //dm.Email = Session["regemail"].ToString();
                ManagerRepository mr = new ManagerRepository();
                mr.Insert(a);
                return RedirectToAction("ManagersManagement");
            }
        }


        [HttpGet]
        public ActionResult ManagerUpdate(int id)
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ManagerRepository ar = new ManagerRepository();

                Manager p;

                p = ar.GetAll().Where(x => x.Id == id).FirstOrDefault();

                if (p != null)
                {
                    return View(p);
                }
                else
                {
                    return RedirectToAction("ManagersManagement");
                }
            }
        }

        [HttpPost]
        public ActionResult ManagerUpdate(Manager a)
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ManagerRepository ar = new ManagerRepository();

                ar.Update(a);

                return RedirectToAction("ManagersManagement");
            }
        }

        [HttpGet]
        public ActionResult DoctorsManagement()
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                DoctorRepository dr = new DoctorRepository();
                var doctors = dr.GetAll();
                return View(doctors);
            }

        }

        [HttpGet]
        public ActionResult ApproveLoginDoctor(int id)
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                LoginRepository ld = new LoginRepository();
                ld.UpdateLoginStatus(id, 1);
                return RedirectToAction("DoctorsManagement");
            }
        }

        [HttpGet]
        public ActionResult RejectLoginDoctor(int id)
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                LoginRepository lm = new LoginRepository();
                lm.UpdateLoginStatus(id, 2);
                return RedirectToAction("DoctorsManagement");
            }
        }

        [HttpGet]
        public ActionResult DeliveryManManagement()
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                DeliveryManRepository dr = new DeliveryManRepository();
                var deliverymans = dr.GetAll();
                return View(deliverymans);
            }
        }

        [HttpGet]
        public ActionResult ApproveLoginDeliveryMan(int id)
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                LoginRepository lm = new LoginRepository();
                lm.UpdateLoginStatus(id, 1);
                return RedirectToAction("DeliveryManManagement");
            }
        }

        [HttpGet]
        public ActionResult RejectLoginDeliveryMan(int id)
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                LoginRepository lm = new LoginRepository();
                lm.UpdateLoginStatus(id, 2);
                return RedirectToAction("DeliveryManManagement");
            }
        }

        [HttpGet]
        public ActionResult DeliverymanCreate()
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                DeliveryMan dm = new DeliveryMan();
                ZoneRepository zon = new ZoneRepository();
                DeliveryManZone combbo = new DeliveryManZone();
                combbo.DeliveryMan = dm;
                combbo.Zones = zon.GetAll();
                return View(combbo);
            }

        }

        [HttpPost]
        public ActionResult DeliverymanCreate(DeliveryMan dm, string Password, string Email)
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                string filename = Path.GetFileNameWithoutExtension(dm.Imagefile.FileName);
                string extention = Path.GetExtension(dm.Imagefile.FileName);
                filename = filename + DateTime.Now.ToString("yyssmmfff") + extention;
                dm.Image = "~/Image/" + filename;
                filename = Path.Combine(Server.MapPath("~/Image/"), filename);
                dm.Imagefile.SaveAs(filename);

                var log = new LoginRepository();
                Login lo = new Login();

                lo.Email = dm.Email;
                lo.Password = Password;
                lo.Type = "DeliveryMan";
                lo.RegistrationStatus = 1;
                lo.LoginStatus = 1;

                log.Insert(lo);

                lo = log.Getthat(dm.Email.ToString());
                dm.LoginId = lo.Id;

                DeliveryManRepository dc = new DeliveryManRepository();
                //dm.Email = Session["regemail"].ToString();
                dc.Insert(dm);
                return RedirectToAction("DeliveryManManagement");
            }
        }


        [HttpGet]
        public ActionResult DeliverymanUpdate(int id)
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                DeliveryManRepository ar = new DeliveryManRepository();

                DeliveryMan p;

                p = ar.GetAll().Where(x => x.Id == id).FirstOrDefault();

                if (p != null)
                {
                    return View(p);
                }
                else
                {
                    return RedirectToAction("DeliveryManManagement");
                }
            }
        }

        [HttpPost]
        public ActionResult DeliverymanUpdate(DeliveryMan a)
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                DeliveryManRepository ar = new DeliveryManRepository();

                ar.Update(a);

                return RedirectToAction("DeliveryManManagement");
            }
        }

        [HttpGet]
        public ActionResult ConsumersManagement()
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ConsumerRepository cr = new ConsumerRepository();
                var consumers = cr.GetAll();
                return View(consumers);
            }

        }

        [HttpGet]
        public ActionResult ApproveLoginConsumer(int id)
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                LoginRepository ld = new LoginRepository();
                ld.UpdateLoginStatus(id, 1);
                return RedirectToAction("ConsumersManagement");
            }
        }

        [HttpGet]
        public ActionResult RejectLoginConsumer(int id)
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                LoginRepository lm = new LoginRepository();
                lm.UpdateLoginStatus(id, 2);
                return RedirectToAction("ConsumersManagement");
            }
        }


        [HttpGet]
        public ActionResult DoctorRegistration()
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                DoctorRepository dr = new DoctorRepository();
                var doctors = dr.GetAll();
                return View(doctors);
            }
        }

        [HttpGet]
        public ActionResult ApproveDoctorRegistration(int id)
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                LoginRepository lm = new LoginRepository();
                lm.ApproveUserRegistration(id);
                return RedirectToAction("DoctorRegistration");
            }
        }

        [HttpGet]
        public ActionResult RejectDoctorRegistration(int id)
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                LoginRepository lm = new LoginRepository();
                lm.RejectUserUserRegistration(id);
                return RedirectToAction("DoctorRegistration");
            }
        }

        [HttpGet]
        public ActionResult ApproveAllDoctorRegistration()
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                LoginRepository lm = new LoginRepository();
                lm.AproveAllPendingDoctors();
                return RedirectToAction("DoctorRegistration");
            }
        }


        [HttpGet]
        public ActionResult ConsumerRegistration()
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ConsumerRepository dr = new ConsumerRepository();
                var consumers = dr.GetAll();
                return View(consumers);
            }
        }

        [HttpGet]
        public ActionResult ApproveConsumerRegistration(int id)
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                LoginRepository lm = new LoginRepository();
                lm.ApproveUserRegistration(id);
                return RedirectToAction("ConsumerRegistration");
            }
        }

        [HttpGet]
        public ActionResult RejectConsumerRegistration(int id)
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                LoginRepository lm = new LoginRepository();
                lm.RejectUserUserRegistration(id);
                return RedirectToAction("ConsumerRegistration");
            }
        }

        [HttpGet]
        public ActionResult ApproveAllConsumerRegistration()
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                LoginRepository lm = new LoginRepository();
                lm.AproveAllPendingConsumers();
                return RedirectToAction("ConsumerRegistration");
            }
        }
    }
}