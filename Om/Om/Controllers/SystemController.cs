using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Om.Controllers
{
    public class SystemController : Controller
    {
        // GET: System
        public ActionResult ModuleManage()
        {
            return View();
        }
        public ActionResult RoleManage()
        {
            return View();
        }
        public ActionResult UserManage()
        {
            return View();
        }
        public ActionResult UserAdd()
        {
            return View();
        }
    }
}