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
    public class ProductController : Controller
    {
        ProductPostRepository contex = new ProductPostRepository();
        // GET: Product
        public ActionResult Index()
        {
            return View(contex.GetAll());
        }


        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SearchResult(string searchBox)
        {

            return View(contex.GetByName(searchBox));
        }


        public ActionResult Details(int id)
        {
            return View(contex.Get(id));
        }

        public ActionResult Create()
        {
            var cont = new CategoryRepository();
            var p = new Product();
            var commbo = new ProductCategory();
            commbo.Product = p;
            commbo.Categories = cont.GetAll();
            return View(commbo);
        }
        [HttpPost]
        public ActionResult Create(Product pro)
        {
           
            string filename = Path.GetFileNameWithoutExtension(pro.Imagefile.FileName);
            string extention = Path.GetExtension(pro.Imagefile.FileName);
            filename = filename + DateTime.Now.ToString("yyssmmfff") + extention;
            pro.Image = "~/Image/" + filename;
            filename = Path.Combine(Server.MapPath("~/Image/"), filename);
            pro.Imagefile.SaveAs(filename);
            var manager = new Manager();
            var managerrepo = new ManagerRepository();
            
            manager = managerrepo.GetManagerByEmail(Session["logged_Email"].ToString());
            pro.ManagerId = manager.Id;
            
            contex.Insert(pro);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var cont = new CategoryRepository();
            var p = contex.Get(id);
            var commbo = new ProductCategory();
            commbo.Product = p;
            commbo.Categories = cont.GetAll();
            return View(commbo);
        }
        [HttpPost]
        public ActionResult Edit(Product dm)
        {
           
            if (dm.Imagefile == null)
            {
                var manager = new Manager();
                var managerrepo = new ManagerRepository();

                manager = managerrepo.GetManagerByEmail(Session["logged_Email"].ToString());
                dm.ManagerId = manager.Id;

                contex.Update(dm);
                return RedirectToAction("Index");

            }
            else
            {
                string filename = Path.GetFileNameWithoutExtension(dm.Imagefile.FileName);
                string extention = Path.GetExtension(dm.Imagefile.FileName);
                filename = filename + DateTime.Now.ToString("yyssmmfff") + extention;
                dm.Image = "~/Image/" + filename;
                filename = Path.Combine(Server.MapPath("~/Image/"), filename);
                dm.Imagefile.SaveAs(filename);

                var manager = new Manager();
                var managerrepo = new ManagerRepository();

                manager = managerrepo.GetManagerByEmail(Session["logged_Email"].ToString());
                dm.ManagerId = manager.Id;

                contex.Insert(dm);
                return RedirectToAction("Index");

            }


        }
        public ActionResult Delete(int id)
        {

            return View(contex.Get(id));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {

            contex.Delete(id);
            return View("Index");
        }
    }
}
