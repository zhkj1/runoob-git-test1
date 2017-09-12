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
    [LoginAuthorize]
    public class SystemController : Controller
    {
       // [ModuleAuthorize]
        // GET: System
        public ActionResult ModuleManage()
        {
            ModuleBll Bll = new ModuleBll();
            List<Module> list = Bll.GetModuleList();
            return View(list);
        }
        [ModuleAuthorize]
        public ActionResult RoleManage()
        {
            RoleBll Bll = new RoleBll();
            var modellist = Bll.GetRoleList();
            return View(modellist);
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
        [ModuleAuthorize]
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
        public ActionResult RoleModuleOperate()
        {
            return View();
        }
        //角色添加
        public ActionResult RoleAdd()
        {
            Role model = new Role();
            RoleBll bll = new RoleBll();
            if (Request.QueryString["RoleId"] != null)
            {
                model = bll.GetModel(int.Parse(Request.QueryString["RoleId"]));
            }
           
            return View(model);
        }
        public ActionResult RoleUserAdd()
        {
            return View();
        }
    }
}