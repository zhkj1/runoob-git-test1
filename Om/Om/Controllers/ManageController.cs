﻿using System;
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
            List<Sys_CauseSuggestion> list = bll.GetList();

            Sys_CauseSuggestion model = new Sys_CauseSuggestion();
            if (Request.QueryString["id"] != null)
            {
                model = bll.GetModel(int.Parse(Request.QueryString["id"]));
            }
            ViewBag.list = list;
            return View(model);
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
        [ModuleAuthorize]
        public ActionResult YujingList()
        {
            return View();
        }
        [ModuleAuthorize]
        public ActionResult SettingList()
        {
            M_HitchInfoBll bll = new M_HitchInfoBll();

            return View(bll.GetSettingModel());
        }
        [ModuleAuthorize]
        public ActionResult DailyList()
        {
            return View();
        }
        [ModuleAuthorize]
        public ActionResult MonthList()
        {
            return View();
        }
        [ModuleAuthorize]
        public ActionResult YearList()
        {
            return View();
        }
        public ActionResult yujilist()
        {
            return View();
        }
    }
}