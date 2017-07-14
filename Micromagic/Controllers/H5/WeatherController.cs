using Micromagic.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Micromagic.Controllers.H5
{
    public class WeatherController : MasterH5Controller
    {
        // GET: Weather
        public ActionResult Index()
        {
            return View();
        }

    }
}