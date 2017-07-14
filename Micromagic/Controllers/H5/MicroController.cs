using Micromagic.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Micromagic.Controllers.H5
{
    public class MicroController : MasterH5Controller
    {
        // GET: Micro
        public ActionResult Index()
        {
            return Redirect("/Weather/Index");
            //return View();
        }
    }
}