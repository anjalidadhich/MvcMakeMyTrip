using RoleBasedAuthanticationInMvc.CustomFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoleBasedAuthanticationInMvc.Controllers
{
    public class HomeController : Controller
    {
        [AuthLog(Roles="Admin")]
        public ActionResult Index()
        {
            ViewBag.Email = TempData["User"].ToString();
                return View();
        }
        [Authorize(Roles ="Admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}