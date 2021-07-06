using PharmaAssist2._0.Models;
using PharmaAssist2._0.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PharmaAssist2._0.Controllers
{
    public class ManagerController : Controller
    {
        ManagerRepository context = new ManagerRepository();

        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Manager c)
        {
            Session["logged_id"] = 1;


            string filename = Path.GetFileNameWithoutExtension(c.Imagefile.FileName);
            string extention = Path.GetExtension(c.Imagefile.FileName);
            filename = filename + DateTime.Now.ToString("yyssmmfff") + extention;
            c.Image = "~/Image/" + filename;
            filename = Path.Combine(Server.MapPath("~/Image/"), filename);
            c.Imagefile.SaveAs(filename);


            var x = context.GetManagerById(Session["logged_id"].GetHashCode());
            c.LoginId = x.Id;
            return View(c);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            context.GetAll();
            return View(context.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(Manager c)
        {
            //Session["logged_id"] = 1;

            string filename = Path.GetFileNameWithoutExtension(c.Imagefile.FileName);
            string extention = Path.GetExtension(c.Imagefile.FileName);
            filename = filename + DateTime.Now.ToString("yyssmmfff") + extention;
            c.Image = "~/Image/" + filename;
            filename = Path.Combine(Server.MapPath("~/Image/"), filename);
            c.Imagefile.SaveAs(filename);

            var x = context.GetManagerById(Session["logged_id"].GetHashCode());
            c.LoginId = x.Id;

            context.Update(c);
            
            return RedirectToAction("Index");
        }

    }
}