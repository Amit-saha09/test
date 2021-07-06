using PharmaAssist2._0.Models;
using PharmaAssist2._0.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PharmaAssist2._0.Controllers
{
    public class ChangePasswordController : Controller
    {
        // GET: ChangePassword
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public ActionResult Index(Login login, string newPassword, string connewPassword)
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                string msg = "";
                bool validate = true;
                LoginRepository lr = new LoginRepository();
                Login user = lr.GetUserByID((int)Session["logged_id"]);

                if (user.Password != login.Password)
                {
                    msg = msg + "\nCurrent Password Doesn't Match.";
                    validate = false;
                }

                if (newPassword.Trim().Length < 4)
                {
                    msg = msg + "\nNew Password Must Have 4 Charecters.";
                    validate = false;
                }

                if (!newPassword.Equals(connewPassword))
                {
                    msg = msg + "\nNew Password and Confirm Password Doesn't Match.";
                    validate = false;
                }

                if (!validate)
                {
                    TempData["Error"] = msg;
                    return RedirectToAction("Index");
                }
                else
                {
                    user.Password = connewPassword;

                    lr.Update(user);

                    return RedirectToAction("Index", "Logout");

                }
            }

        }
    }
}