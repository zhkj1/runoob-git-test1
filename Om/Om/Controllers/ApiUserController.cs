﻿using BLL;
using LeaRun.Utilities;
using MallWCF.DBHelper;
using Model;
using Model.ModelView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace Om.Controllers
{
    public class ApiUserController : ApiController
    {
        UserBll UserBll = new UserBll();
        [HttpPost]
        public Dictionary<string, object> GetUerList(JqGridParam jqgridparam)
        {
            DataTable data = UserBll.GetPageList(ref jqgridparam);
            return new Dictionary<string, object>
            {
                { "code",1},
                { "total",jqgridparam.total},
                { "page",jqgridparam.page},
                { "records",jqgridparam.records},
                { "rows",data},
            };

        }
        [HttpPost]
        public Dictionary<string, object> CreateUser(BaseUser model)
        {
            model.UserPassword= Md5Helper.MD5(DESEncrypt.Encrypt(model.UserPassword.ToLower(), "qwertyui"));
            return UserBll.AddUser(model, 1);
        }
        [HttpPost]
        //用户添加角色用户列表
        public Dictionary<string, object> RoleUserList()
        {
            var context = (HttpContextBase)Request.Properties["MS_HttpContext"];
            var request = context.Request;
            string roleid = request.Form["roleid"];
            IDatabase database = DataFactory.Database();
            var ds = database.FindDataSetBySql(" select  a.userId,a.Account,b.RoleId from BaseUser a left join UserRole b on a.UserId=b.UserId   where a.[UserId]   in (select [UserId] from [UserRole] where roleId="+roleid+"  ) or a.[UserId] not in(select [UserId] from [UserRole])");
            List<UserRoleViewModel> list = new List<UserRoleViewModel>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                UserRoleViewModel model = new UserRoleViewModel();
                model.UserId = ds.Tables[0].Rows[i]["userId"].ToString();
                model.UserName = ds.Tables[0].Rows[i]["Account"].ToString();
                if (roleid == ds.Tables[0].Rows[i]["RoleId"].ToString())
                {
                    model.IsChecked = true;
                }
                else
                {
                    model.IsChecked = false;
                }
                list.Add(model);
            }
            return new Dictionary<string, object>
            {
                { "code","1"},
                { "list",list}
            };


        }
        /// <summary>
        /// 角色添加用户
        /// </summary>
        /// <returns></returns>
       [HttpPost]
        public Dictionary<string, object> UserRoleAdd()
        {
            var context = (HttpContextBase)Request.Properties["MS_HttpContext"];
            var request = context.Request;
            string roleid = request.Form["roleid"];
            string userid = request.Form["userid"];
            IDatabase database = DataFactory.Database();
            DbTransaction isOpenTrans = database.BeginTrans();
            string[] arruserid = userid.Split(',');
            try
            {
                StringBuilder sbUserRole = new StringBuilder("delete  UserRole where RoleId=" + roleid);
                database.ExecuteBySql(sbUserRole);
                List<UserRole> list = new List<UserRole>();
                for (int i = 0; i < arruserid.Length; i++)
                {
                    UserRole model = new UserRole();
                    model.RoleId = int.Parse(roleid);
                    model.UserId = int.Parse(arruserid[i]);
                    list.Add(model);
                    database.Insert<UserRole>(model, isOpenTrans);
                }
                database.Commit();
                SysLogBll sysLogBll = new SysLogBll();
                sysLogBll.WriteLog<UserRole>(list, Utilities.OperationType.Add,(int)Utilities.LogSatus.Success, "角色添加用户");
                return new Dictionary<string, object>
                {
                    { "code","1"}
                };


            }
            catch (Exception)
            {
                database.Rollback();
                return new Dictionary<string, object>
                {
                    { "code","0"}
                };
            }
        }


    }
}
