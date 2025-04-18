using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using School_Management_System.Models;

namespace School_Management_System.Controllers
{
    public class AnalyticsController : Controller
    {
        // GET: Analytics

        BusinessLayer objBus=new BusinessLayer();
        public ActionResult AnalyticsDashboard()
        {

            return View();
        }
    }
}