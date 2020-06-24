using RoleBasedAuthanticationInMvc.CustomFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoleBasedAuthanticationInMvc.Controllers
{
    public class AdminController : Controller
    {
        [AuthLog(Roles = "Admin")]
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}