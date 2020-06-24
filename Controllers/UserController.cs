using RoleBasedAuthanticationInMvc.CustomFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoleBasedAuthanticationInMvc.Controllers
{
    public class UserController : Controller
    {
        [AuthLog(Roles ="User")]
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
    }
}