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
    public class DoctorController : Controller
    {
        DoctorRepository contex = new DoctorRepository();
        // GET: Doctor
        public ActionResult Index()
        {
            return View(contex.GetAll());
        }
        public ActionResult Details(int Id)
        {
            var p = new BlogPostRepository();
            ViewData["userblog"] = p.GetUserPosts(Id);
            return View(contex.Get(Id));
        }
        public ActionResult Edit(int id)
        {
            SpecialistRepository db = new SpecialistRepository();
            Doctor p = new Doctor();
            p = contex.Get(id);

            DoctorSpecialist combodata = new DoctorSpecialist();
            combodata.Doctor = p;
            combodata.Specialists = db.GetAll();
            var q = new BlogPostRepository();
            ViewData["userblog"] = q.GetUserPosts(id);


            return View(combodata);

        }


        [HttpPost]
        public ActionResult Edit(Doctor doc)
        {
            string filename = Path.GetFileNameWithoutExtension(doc.Imagefile.FileName);
            string extention = Path.GetExtension(doc.Imagefile.FileName);
            filename = filename + DateTime.Now.ToString("yyssmmfff") + extention;
            doc.Image = "~/Image/" + filename;
            filename = Path.Combine(Server.MapPath("~/Image/"), filename);
            doc.Imagefile.SaveAs(filename);

            var log = new LoginRepository();
            Login lo = new Login();

            lo = log.Getthat(doc.Email);
            doc.LoginId = lo.Id;
            
            contex.Update(doc);
            return RedirectToAction("Index");

        }
        public ActionResult Create()
        {
            SpecialistRepository db = new SpecialistRepository();
            Doctor p = new Doctor();
           
            DoctorSpecialist combodata = new DoctorSpecialist();
            combodata.Doctor = p;
            combodata.Specialists = db.GetAll();
            
            return View(combodata);



        }

        [HttpPost]
        public ActionResult Create(Doctor doc)
        {
            string filename = Path.GetFileNameWithoutExtension(doc.Imagefile.FileName);
            string extention = Path.GetExtension(doc.Imagefile.FileName);
            filename = filename + DateTime.Now.ToString("yyssmmfff") + extention;
            doc.Image = "~/Image/" + filename;
            filename = Path.Combine(Server.MapPath("~/Image/"), filename);
            doc.Imagefile.SaveAs(filename);

            var log = new LoginRepository();
            Login lo = new Login();

            lo = log.Getthat(Session["regemail"].ToString());
            doc.LoginId = lo.Id;
            doc.Email = Session["regemail"].ToString();
            contex.Insert(doc);
            return RedirectToAction("Index");






        }

        




    }

    
}