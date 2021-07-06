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
    public class BlogPostController : Controller
    {
        BlogPostRepository contex = new BlogPostRepository();
        // GET: BlogPost
        public ActionResult Index()
        {
            return View(contex.GetAll());
        }
        public ActionResult Create()
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Doctor"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Create(BlogPost bp)
        {

         
            string filename = Path.GetFileNameWithoutExtension(bp.Imagefile.FileName);
            string extention = Path.GetExtension(bp.Imagefile.FileName);
            filename = filename + DateTime.Now.ToString("yyssmmfff") + extention;
            bp.Image = "~/Image/" + filename;
            filename = Path.Combine(Server.MapPath("~/Image/"), filename);
            bp.Imagefile.SaveAs(filename);

            var log = new DoctorRepository();
            Doctor lo = new Doctor();

            lo = log.Getbyemail(Session["logged_Email"].ToString());
            bp.DoctorId = lo.Id;
           
            contex.Insert(bp);
            return RedirectToAction("Index");
            
        }
        public ActionResult Edit(int id)
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Doctor"))
            {
                return RedirectToAction("Index", "Login");
            }
            else 
            { 

                var q = new BlogPost();
                q = contex.Get(id);
                return View(q);
             }
        
        }
        [HttpPost]
        public ActionResult Edit(BlogPost bp)
        {
            
            string filename = Path.GetFileNameWithoutExtension(bp.Imagefile.FileName);
            string extention = Path.GetExtension(bp.Imagefile.FileName);
            filename = filename + DateTime.Now.ToString("yyssmmfff") + extention;
            bp.Image = "~/Image/" + filename;
            filename = Path.Combine(Server.MapPath("~/Image/"), filename);
            bp.Imagefile.SaveAs(filename);

            var log = new DoctorRepository();
            Doctor lo = new Doctor();

            lo = log.Getbyemail(Session["logged_Email"].ToString());
            bp.DoctorId = lo.Id;

            contex.Update(bp);
            return RedirectToAction("Index");


        }

        public ActionResult Details(int id)
        {
            
           
            return View(contex.Get(id));
        }

        public ActionResult Delete(int id)
        {


            return View(contex.Get(id));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {

            contex.Delete(id);
            return RedirectToAction("Index", "Doctor", new { area = "" });
        }


    }
}