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
    public class DeliveryManController : Controller
    {
        DeliveryManRepository contex = new DeliveryManRepository();
        // GET: DeliveryMan
        public ActionResult Index()
        {
            return View(contex.GetAll());
        }

        public ActionResult Create()
        {
            DeliveryMan dm = new DeliveryMan();
            ZoneRepository zon = new ZoneRepository();
            DeliveryManZone combbo = new DeliveryManZone();
            combbo.DeliveryMan = dm;
            combbo.Zones = zon.GetAll();
            return View(combbo);
        }
        [HttpPost]
        public ActionResult Create(DeliveryMan dm, string Password)
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
            
            //dm.Email = Session["regemail"].ToString();
            contex.Insert(dm);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            DeliveryMan dm = new DeliveryMan();
            ZoneRepository zon = new ZoneRepository();
            dm = contex.Get(id);
            DeliveryManZone combbo = new DeliveryManZone();
            combbo.DeliveryMan = dm;
            combbo.Zones = zon.GetAll();
            return View(combbo);
        }

        [HttpPost]
        public ActionResult Edit(DeliveryMan dm)
        {
            if (dm.Imagefile == null)
            {
                var log = new LoginRepository();
                Login lo = new Login();

                lo = log.Getthat(dm.Email.ToString());
                dm.LoginId = lo.Id;

                //dm.Email = Session["regemail"].ToString();
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

                var log = new LoginRepository();
                Login lo = new Login();


                lo = log.Getthat(dm.Email.ToString());
                dm.LoginId = lo.Id;

                //dm.Email = Session["regemail"].ToString();
                contex.Update(dm);
                return RedirectToAction("Index");

            }


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
            return View("Index");
        }
    }
}