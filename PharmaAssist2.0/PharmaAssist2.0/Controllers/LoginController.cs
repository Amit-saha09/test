using PharmaAssist2._0.Models;
using PharmaAssist2._0.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PharmaAssist2._0.Controllers
{
    public class LoginController : Controller
    {
        LoginRepository contex = new LoginRepository();
        // GET: Lgin
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Login P)
        {
            Login valid = contex.Getregistared(P.Email);
            if (valid!=null)
            {
                ViewData["valid-msg"] = "This Email already Used";
                return RedirectToAction("Registration");
            }
            else
            {

                if (P.Type == "Doctor")
                {
                    P.RegistrationStatus = 3;
                    P.LoginStatus = 2;
                    contex.Insert(P);
                    Session["regemail"] = P.Email.ToString();
                    return RedirectToAction("Create", "Doctor", new { area = "" }); 
                }
                else if (P.Type == "Consumer")
                {
                    P.RegistrationStatus = 3;
                    P.LoginStatus = 2;
                    contex.Insert(P);
                    Session["regemail"] = P.Email.ToString();
                    return RedirectToAction("Create", "Consumer", new { area = "" });

                }
                
                else
                {
                    ViewData["Email"] = P.Email;
                    ViewData["valid-msg"] = "Please Select a Type";
                    return RedirectToAction("Registration");
                }
            }

        }

        [HttpGet]
        public ActionResult Index()
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null)
            {
                return View();
            }
            else
            {
                if (Session["logged_type"].Equals("Admin"))
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (Session["logged_type"].Equals("Doctor"))
                {
                     return RedirectToAction("Homepage", "Doctor");
                }
                
                else if (Session["logged_type"].Equals("Manager"))
                {
                    return RedirectToAction("Index", "Manager");
                }
               
                
                else if (Session["logged_type"].Equals("Consumer"))
                {
                     return RedirectToAction("Index", "Consumer");
                }
                
                else
                {
                    Session.Clear();
                    Session.Abandon();
                    TempData["error"] = "Login Restricted! Contact admin";
                    return RedirectToAction("Index", "Login");
                }
            }
        }

        [HttpPost]
        public ActionResult Index(Login user)
        {
            LoginRepository lr = new LoginRepository();

            var userFromDB = lr.GetUser(user);



            if (userFromDB != null)
            {
                if(userFromDB.LoginStatus == 1 && userFromDB.RegistrationStatus == 1)
                {
                    Session["logged_id"] = userFromDB.Id;
                    Session["logged_type"] = userFromDB.Type;
                    Session["logged_Email"] = userFromDB.Email;

                    if (Session["logged_type"].Equals("Admin") && userFromDB.LoginStatus == 1 && userFromDB.RegistrationStatus == 1)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else if (Session["logged_type"].Equals("Doctor") && userFromDB.LoginStatus == 1 && userFromDB.RegistrationStatus == 1)
                    {
                         return RedirectToAction("Homepage", "Doctor");

                    }
                    else if (Session["logged_type"].Equals("DeliveryMan") && userFromDB.LoginStatus == 1 && userFromDB.RegistrationStatus == 1)
                    {
                         return RedirectToAction("Homepage", "DeliveryMan");
                    }
                   
                    else if (Session["logged_type"].Equals("Manager") && userFromDB.LoginStatus == 1 && userFromDB.RegistrationStatus == 1)
                    {
                         return RedirectToAction("Index", "Manager");
                    }
                    
                    
                    else if (Session["logged_type"].Equals("Consumer") && userFromDB.LoginStatus == 1 && userFromDB.RegistrationStatus == 1)
                    {
                         return RedirectToAction("index", "Consumer");
                    }
                   
                    else
                    {
                        Session.Clear();
                        Session.Abandon();
                        TempData["error"] = "Login Restricted! Contact admin";
                        return RedirectToAction("Index", "Login");
                    }
                }
                else
                {
                    TempData["error"] = "Login Restricted! Contact admin";
                    return RedirectToAction("Index", "Login");
                }
            }
            else
            {
                TempData["error"] = "Invalid Email/Password. Please try again.";
                return RedirectToAction("Index", "Login");
            }

        }
    }
}