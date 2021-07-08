using PharmaAssist2._0.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PharmaAssist2._0.Controllers
{
    public class ProblemPostController : Controller
    {
        ProblemPostRepository contex = new ProblemPostRepository();
        // GET: ProblemPost
        public ActionResult Index()
        {
           
            return View(contex.GetAll());
        }

    }
}