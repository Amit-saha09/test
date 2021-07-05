using PharmaAssist2._0.Models;
using PharmaAssist2._0.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PharmaAssist2._0.Controllers
{
    public class UserController : Controller
    {
        ProblemPostRepository context = new ProblemPostRepository();
        DoctorRepository Dcontext = new DoctorRepository();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FindDoctor()
        {
            var FindDoctor = Dcontext.GetAll();
            return View(FindDoctor);
        }

        public ActionResult ProblemPost()
        {
            var data = new ConsumerRepository();

            return View();
        }


        [HttpPost]
        public ActionResult ProblemPost(ProblemPost p)
        {

            var s = new ConsumerRepository();
            var t = new Consumer();
            t = s.GetbyLogin(3);
            p.ConsumerId = t.Id;

            context.Insert(p);
            return RedirectToAction("Index");
        }

    }
}