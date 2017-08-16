using BLL;
using LeaRun.Utilities;
using MallWCF.DBHelper;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    }
}
