using BLL;
using MallWCF.DBHelper;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Utilities.Base.File;

namespace Om.Controllers
{
    public class ApiM_HitchInfoController : ApiController
    {
        M_HitchInfoBll M_HitchInfoBll = new M_HitchInfoBll();
        [HttpPost]
        //故障导入
        public Dictionary<string, object> LeadingInM_HitchInfo()
        {
          
            string datetime = HttpContext.Current.Request.Form["leadingindatetime"].ToString();
            string url= HttpContext.Current.Request.Form["url"].ToString();
            string filename = HttpContext.Current.Request.Form["filename"].ToString();
            DataSet ds = ExportFile.ExcelSqlConnection(HttpContext.Current.Server.MapPath(url), "Info");           //调用自定义方法
            DataRow[] dr = ds.Tables[0].Select();
            int successcount = 0;
            int failcount = 0;
            for (int i = 0; i < dr.Length; i++)
            {
                try
                {
                    M_HitchInfo model = new M_HitchInfo();
                    model.AreaName = dr[0][0].ToString();
                    model.FactorySation = dr[i][1].ToString();
                    model.Signal = dr[i][2].ToString();
                    model.HappenTimes = int.Parse(dr[i][3].ToString());
                    model.SignalType = dr[i][4].ToString();
                    model.HappenTimes1 = int.Parse(dr[i][5].ToString());
                    model.MessageType = dr[i][6].ToString();
                    model.CreateUserId = 1;
                    model.CreateUserName = "admin";
                    model.CreateTime = DateTime.Parse(datetime);
                    if (M_HitchInfoBll.M_HitchInfoAdd(model) > 0)
                    {
                        successcount++;
                    }
                    else
                    {
                        failcount++;
                    }

                }
                catch (Exception)
                {

                    failcount++;
                }
               
            }
            return new Dictionary<string, object>
            {
                { "code","1"},
                { "successcount",successcount},
                { "failcount",failcount},
                { "filename",filename},
                { "count",dr.Length}

            };

        }

        [HttpPost]
        public Dictionary<string, object> LeadingInList(JqGridParam jqgridparam)
        {

            DataTable data = M_HitchInfoBll.GetPageList(ref jqgridparam);
            return new Dictionary<string, object>
            {
                { "code",1},
                { "total",jqgridparam.total},
                { "page",jqgridparam.page},
                { "records",jqgridparam.records},
                { "rows",data},
            };
        }
    }
}
