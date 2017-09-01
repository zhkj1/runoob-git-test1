using BLL;
using LeaRun.Utilities;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MallWCF.DBHelper;
using System.Data.Common;
using System.Text;
using System.Data;
using System.Data.SqlClient;

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
        //获取所有模块
        [HttpPost]
        public Dictionary<string, object> GetAllOperate()
        {
            ModuleBll ModuleBll = new ModuleBll();
            ModuleOperateBll ModuleOperateBll = new ModuleOperateBll();
            List<Module> listmodel = ModuleBll.GetModuleList();
            List<ModuleOperate> moduleoperate = ModuleOperateBll.GetList();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            OpeateModuleView model = new OpeateModuleView();
            List<ModuleView> listModuleView = new List<ModuleView>();
          
            foreach (var item in listmodel)
            {
                ModuleView ModuleView = new ModuleView();
                ModuleView.ModuleId = item.ModuleId;
                ModuleView.ModuleName = item.ModuleName;
                ModuleView.ParentId = item.ParentId;
                ModuleView.ischecked = true;
                ModuleView.id = item.ModuleId;
                List<ModuleOperateView> listModuleOperateView = new List<ModuleOperateView>();
                foreach (var item1 in moduleoperate)
                {
                    ModuleOperateView moduleOperateView = new ModuleOperateView();
                    if (item.ModuleId == item1.ModuleId)
                    {
                        moduleOperateView.IsCheck = false;
                        moduleOperateView.OperateId = item1.ModuleOperateId;
                        moduleOperateView.OperateName = item1.ModuleOperateName;
                       
                        listModuleOperateView.Add(moduleOperateView);
                    }
                }
                ModuleView.List = listModuleOperateView;
                listModuleView.Add(ModuleView);
            }
         
            model.ModuleList = listModuleView;
            dic.Add("module", model);
            return dic;
        }
        [HttpPost]
        //复权
        public Dictionary<string, object> CreateModuleOperate()
        {
            var context = (HttpContextBase)Request.Properties["MS_HttpContext"];
            var request = context.Request;
            string operate = request.Form["operate"];
            string roleid = request.Form["roleid"];
            OpeateModuleView model = operate.JsonToEntity<OpeateModuleView>();
            IDatabase database = DataFactory.Database();
            DbTransaction isOpenTrans = database.BeginTrans();
            try
            {
                StringBuilder sbModuleOperateRole = new StringBuilder("delete  ModuleOperateRole where RoleId=@RoleId");
                SqlParameter[] par = { new SqlParameter("@RoleId", SqlDbType.Int) };
                par[0].Value = int.Parse(roleid);
                int newid = database.ExecuteBySql(sbModuleOperateRole, par, isOpenTrans);
                StringBuilder sbModuleRole = new StringBuilder("delete ModuleRole where RoleId=@RoleId");
                int newid1= database.ExecuteBySql(sbModuleRole, par, isOpenTrans);
              
                foreach (var item in model.ModuleList)
                {
                    if (item.ischecked)
                    {
                        ModuleRole moduleRole = new ModuleRole();
                        moduleRole.RoleId = int.Parse(roleid);
                        moduleRole.ModuleId = item.ModuleId;
                        database.Insert(moduleRole, isOpenTrans);
                        foreach (var item1 in item.List)
                        {
                            if (item1.IsCheck)
                            {
                                ModuleOperateRole moduleOperateRole = new ModuleOperateRole();
                                moduleOperateRole.RoleId= int.Parse(roleid);
                                moduleOperateRole.ModuleOperateId = item1.OperateId;
                                database.Insert(moduleOperateRole, isOpenTrans);
                            }
                        }
                    }

                    
                }
                database.Commit();
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
