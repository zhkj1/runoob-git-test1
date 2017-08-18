using BLL;
using LeaRun.Utilities;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Om.Controllers
{
    public class ApiModuleOperateController : ApiController
    {
        ModuleOperateBll ModuleOperateBll = new ModuleOperateBll();
        //模块操作添加
        public Dictionary<string, object> OperateAdd(ModuleOperate model)
        {
            model.CreateTime = DateTime.Now;
            model.CreateUserId = ManageProvider.Provider.Current().UserId;
            model.CreateUserName = ManageProvider.Provider.Current().Account;
            if (ModuleOperateBll.ModuleOperateAdd(model) > 0)
            {
                return new Dictionary<string, object>
                  {
                      { "code",1},
                  };
            }
            else
            {
                return new Dictionary<string, object>
                  {
                      { "code",0},
                      { "msg","添加失败"}
                  };

            }

        }
    }
}
