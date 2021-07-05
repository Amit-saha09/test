using PharmaAssist2._0.Repository;
using PharmaAssist2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace PharmaAssist2._0.Controllers
{
    public class AdminController : Controller
    {
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

        [HttpPost]
        public ActionResult AdminsManagement(FormCollection form)
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                Login loginToInsert = new Login();
                loginToInsert.Email = form["emailTB"];
                loginToInsert.Password = form["passTB"];
                loginToInsert.LoginStatus = 1;
                loginToInsert.RegistrationStatus = 1;
                loginToInsert.Type = "Admin";

                LoginRepository lr = new LoginRepository();
                int id = lr.InsertLoginGetID(loginToInsert);

                if (id < 1)
                {
                    TempData["error"] = "Try Again. Maybe Email Exists.";
                }
                else
                {
                    Admin adminToInsert = new Admin();
                    adminToInsert.Name = form["nameTB"];
                    adminToInsert.Phone = form["phoneTB"];
                    adminToInsert.Address = form["addressTB"];
                    adminToInsert.Image = "~/Image/PharmaAssist_Default_User_Image.png";
                    adminToInsert.Gender = form["gender"];
                    adminToInsert.Salary = Int32.Parse(form["salaryTB"]);
                    adminToInsert.Dob = DateTime.Parse(form["dobTB"]);
                    adminToInsert.LoginId = id;

                    AdminRepository ar = new AdminRepository();

                    bool insertion = ar.InsertAdmin(adminToInsert);

                    if (!insertion)
                    {
                        TempData["error"] = "Something Went Wrong";
                    }
                }


                return RedirectToAction("AdminsManagement");
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