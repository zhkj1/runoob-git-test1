using BLL;
using Model;
using Om.UserAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Om.Controllers
{
    [LoginAuthorizeAttribute]
    public class SystemController : Controller
    {
        // GET: System
        public ActionResult ModuleManage()
        {
            ModuleBll Bll = new ModuleBll();
            List<Module> list = Bll.GetModuleList();
            return View(list);
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

        public ActionResult ModuleAdd()
        {
            ModuleBll Bll = new ModuleBll();
            List<Module> list = Bll.GetModuleList();
            list = list.Where(a => a.ParentId == 0).ToList();
            ViewBag.ModuleParentList = list;
            return View();
        }

        public ActionResult OperateManage()
        {
            return View();
        }

        public ActionResult OperateList(int moduleid)
        {
            ModuleOperateBll Bll = new ModuleOperateBll();
            List<ModuleOperate> list = Bll.GetModuleOperateListByModuleId(moduleid);
            return View(list);
        }

        public ActionResult OperateAdd()
        {
          
            ModuleOperate model = new ModuleOperate();
            model.ModuleId = int.Parse(Request.QueryString["moduleid"]);
            if (Request.QueryString["id"] == null)
            {
                model.Enabled = 1;
            }
            return View(model);
        }

    }
}