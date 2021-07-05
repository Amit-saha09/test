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
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Manager m)
        {
            string filename = Path.GetFileNameWithoutExtension(m.Imagefile.FileName);
            string extention = Path.GetExtension(m.Imagefile.FileName);
            filename = filename + DateTime.Now.ToString("yyssmmfff") + extention;
            m.Image = "~/Image/" + filename;
            filename = Path.Combine(Server.MapPath("~/Image/"), filename);
            m.Imagefile.SaveAs(filename);

            Session["logged_id"] = 1;
            ConsumerRepository PPRepo = new ConsumerRepository();
            var x = PPRepo.GetConsumerById(Session["logged_id"].GetHashCode());
            m.LoginId = x.Id;
            context.Insert(m);
            return RedirectToAction("Index");
            
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ManagerRepository m = new ManagerRepository();
            ViewData["loginIds"] = m.GetAll();
            return View(m.GetAll(id));
        }
        [HttpPost]
        public ActionResult Edit(Manager man)
        {
            string filename = Path.GetFileNameWithoutExtension(man.Imagefile.FileName);
            string extention = Path.GetExtension(man.Imagefile.FileName);
            filename = filename + DateTime.Now.ToString("yyssmmfff") + extention;
            man.Image = "~/Image/" + filename;
            filename = Path.Combine(Server.MapPath("~/Image/"), filename);
            man.Imagefile.SaveAs(filename);

            var log = new LoginRepository();
            Login lo = new Login();


            man.LoginId = lo.Id;

            context.Update(man);
            return RedirectToAction("Index");
            
        }


    }
}