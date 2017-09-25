using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Om.Models;
using Om.UserAttribute;
using Model;
using BLL;
using System.Collections.Generic;

namespace Om.Controllers
{
    [LoginAuthorize]

    public class ManageController : Controller
    {
        [ModuleAuthorize]
        public ActionResult Cause()
        {
            return View();
        }
        public ActionResult CauseAdd()
        {
            Sys_CauseSuggestionBll bll = new Sys_CauseSuggestionBll();
            List<M_CauseSuggestion> list = bll.GetList();
            ViewBag.list = list;
            return View();
        }
        [ModuleAuthorize]
        //故障列表
        public ActionResult HitchList()
        {
            return View();
        }
        //故障导入
        public ActionResult Hitchleadingin()
        {
            return View();
        }
        [ModuleAuthorize]
        //故障预警
        public ActionResult HitchWarning()
        {
            return View();
        }
    }
}