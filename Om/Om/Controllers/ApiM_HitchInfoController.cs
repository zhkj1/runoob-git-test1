using BLL;
using MallWCF.DBHelper;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Http;
using Utilities.Base.File;
using LeaRun.Utilities;
using System.Xml;
using Model.ModelView;

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
        //预警列表
        [HttpPost]
        public Dictionary<string, object> YujingList(JqGridParam jqgridparam)
        {
            var timetype = HttpContext.Current.Request.Form["timetype"].ToString();
            var datetime= HttpContext.Current.Request.Form["datetime"].ToString();
            var times= HttpContext.Current.Request.Form["times"].ToString();
            var factory = HttpContext.Current.Request.Form["factory"].ToString();
             IDatabase database = DataFactory.Database();
            IRepository<Module> re = new Repository<Module>();
            DataTable data = new DataTable();
            string strwhere = "";
            if (!string.IsNullOrEmpty(factory))
            {
                strwhere = " and FactorySation='" + factory+"'";
            }
            //按照月份删选

            if (timetype == "0")
            {
               
                data = re.FindTablePageBySql("select [FactorySation],[Signal],sum([HappenTimes]) as total from (SELECT [FactorySation],[Signal] ,[HappenTimes] ,[SignalType], [CreateTime]   FROM[ElectricPower].[dbo].[M_HitchInfo] where datediff(month, CreateTime, '"+ datetime + "') = 0 "+ strwhere + ") a group by[FactorySation],[Signal] having sum([HappenTimes])>"+ times + "", ref jqgridparam);

            }
            else {
                 data = re.FindTablePageBySql("select [FactorySation],[Signal],sum([HappenTimes]) as total from (SELECT [FactorySation],[Signal] ,[HappenTimes] ,[SignalType], [CreateTime]   FROM[ElectricPower].[dbo].[M_HitchInfo] where datediff(day, CreateTime, '" + datetime + "') = 0 "+ strwhere + ") a group by[FactorySation],[Signal] having sum([HappenTimes])>"+ times + "", ref jqgridparam);

            }
            return new Dictionary<string, object>
            {
                { "code",1},
                { "total",jqgridparam.total},
                { "page",jqgridparam.page},
                { "records",jqgridparam.records},
                { "rows",data},
            };
        }

        //每天信号统计
        [HttpPost]
        public Dictionary<string, object> DailyList(JqGridParam jqgridparam)
        {
           
            var datetime = HttpContext.Current.Request.Form["datetime"].ToString();
            var factory = HttpContext.Current.Request.Form["factory"].ToString();
            var key = HttpContext.Current.Request.Form["key"].ToString();
            IDatabase database = DataFactory.Database();
            IRepository<Module> re = new Repository<Module>();
            DataTable data = new DataTable();
            string strwhere = " 1=1 ";
            if (!string.IsNullOrEmpty(factory))
            {
                strwhere += " and FactorySation='" + factory + "'";
            }
            if (!string.IsNullOrEmpty(datetime))
            {
                strwhere += " and CreateTime='" + datetime + "'";
            }
            if (!string.IsNullOrEmpty(key))
            {
                strwhere += " and Signal like'%" + key + "%'";
            }
            data = re.FindTablePageBySql("SELECT sum(happentimes) as total,[FactorySation],CreateTime,Signal FROM[ElectricPower].[dbo].[M_HitchInfo] where "+strwhere +"   group by CreateTime,[FactorySation], Signal", ref jqgridparam);
            return new Dictionary<string, object>
            {
                { "code",1},
                { "total",jqgridparam.total},
                { "page",jqgridparam.page},
                { "records",jqgridparam.records},
                { "rows",data},
            };
        }
        //月统计
        [HttpPost]
        public Dictionary<string, object> MonthList(JqGridParam jqgridparam)
        {
            var datetime = HttpContext.Current.Request.Form["datetime"].ToString();
            var factory = HttpContext.Current.Request.Form["factory"].ToString();
            var key = HttpContext.Current.Request.Form["key"].ToString();
            IDatabase database = DataFactory.Database();
            IRepository<Module> re = new Repository<Module>();
            DataTable data = new DataTable();
            string strwhere = " 1=1 ";
            if (!string.IsNullOrEmpty(factory))
            {
                strwhere += " and FactorySation='" + factory + "'";
            }
            if (!string.IsNullOrEmpty(datetime))
            {
                strwhere += " and datediff(month, CreateTime,'" + datetime+"-01" + "') = 0";
              
            }
            if (!string.IsNullOrEmpty(key))
            {
                strwhere += " and Signal like'%" + key + "%'";
            }
            data = re.FindTablePageBySql(" SELECT sum(happentimes) as total,[FactorySation], Signal ,cast(datepart(YEAR, CreateTime) as varchar(4))+'-'+RIGHT('00'+CAST(MONTH(CreateTime) AS VARCHAR(2)),2) as CreateTime FROM[ElectricPower].[dbo].[M_HitchInfo] where "+ strwhere + "  group by  cast(datepart(YEAR, CreateTime) as varchar(4)) + '-' + RIGHT('00' + CAST(MONTH(CreateTime) AS VARCHAR(2)), 2),[FactorySation], Signal", ref jqgridparam);
            return new Dictionary<string, object>
            {
                { "code",1},
                { "total",jqgridparam.total},
                { "page",jqgridparam.page},
                { "records",jqgridparam.records},
                { "rows",data},
            };
        }


        //年统计
        [HttpPost]
        public Dictionary<string, object> YearList(JqGridParam jqgridparam)
        {
            var datetime = HttpContext.Current.Request.Form["datetime"].ToString();
            var factory = HttpContext.Current.Request.Form["factory"].ToString();
            var key = HttpContext.Current.Request.Form["key"].ToString();
            IDatabase database = DataFactory.Database();
            IRepository<Module> re = new Repository<Module>();
            DataTable data = new DataTable();
            string strwhere = " 1=1 ";
            if (!string.IsNullOrEmpty(factory))
            {
                strwhere += " and FactorySation='" + factory + "'";
            }
            if (!string.IsNullOrEmpty(datetime))
            {
                strwhere += " and datediff(Year, CreateTime,'" + datetime + "-01-01" + "') = 0";

            }
            if (!string.IsNullOrEmpty(key))
            {
                strwhere += " and Signal like'%" + key + "%'";
            }
            data = re.FindTablePageBySql("SELECT sum(happentimes) as total,[FactorySation],year(CreateTime) as CreateTime,Signal FROM[ElectricPower].[dbo].[M_HitchInfo] where "+ strwhere + "   group by  year(CreateTime),[FactorySation], Signal", ref jqgridparam);
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
        public Dictionary<string, object> GetYuji()
        {
           
             string factorysation= HttpContext.Current.Request.Form["factorysation"].ToString();
            string signal = HttpContext.Current.Request.Form["signal"].ToString();
            string createtime = HttpContext.Current.Request.Form["createtime"].ToString();
            IDatabase database = DataFactory.Database();
            int totalday = 600;
            var list = database.FindListBySql<M_HitchInfo>("SELECT sum(HappenTimes)AS HappenTimes, CreateTime FROM [M_HitchInfo] where  FactorySation = '"+ factorysation + "' and Signal = '"+signal+"' and DATEDIFF(month, CreateTime, '"+ createtime + "') = 0  group by CreateTime");
            int monthdyas = DateTimeHelper.GetDaysOfMonth(DateTime.Parse(createtime));
            string month = DateTime.Parse(createtime).Month.ToString();
            string year = DateTime.Parse(createtime).Year.ToString();
            //计算出每天的次数集合
            List<int> listtimes = new List<int>();
            for (int i = 1; i < monthdyas+1; i++)
            {
              var model=list.Find(a => a.CreateTime == DateTime.Parse(year + "-" + month +"-" + i.ToString()));
                if (model == null)
                {
                    listtimes.Add(0);
                }
                else
                {
                    listtimes.Add(model.HappenTimes);
                }
            }
            string bili = "2:1";
            string[] arrbili = bili.Split(':');
            //工作日节假日的具体比例
            List<int> shijilist = new List<int>();
            //每月的周末和工作日
            List<int> listdays = DateTimeHelper.GetMonthArr(DateTime.Parse(createtime));
            for (int i = 0; i < listdays.Count; i++)
            {
                //工作日
                if (listdays[i] == 0)
                {
                    shijilist.Add(int.Parse(arrbili[1]));
                }
                else
                {
                    shijilist.Add(int.Parse(arrbili[0]));
                }
            }
            int bilisum = 0;
            foreach (var item in shijilist)
            {
                bilisum += item;
            }
            List<int> shiji = new List<int>();
            List<int> yuji = new List<int>();
            int shijisum = 0;
            for (int i = 0; i < shijilist.Count; i++)
            {
                int shengyu = shijilist[i] * (totalday - M_HitchInfoBll.GetRestCount(listtimes, i)) / (bilisum - (M_HitchInfoBll.GetRestCount(shijilist, i)));
                shiji.Add(listtimes[i]);
                yuji.Add(shengyu);
                shijisum += listtimes[i];
                if (shijisum > totalday)
                {
                    break;
                }
              
            }
            return new Dictionary<string, object>
            {
                {"shijilist",shiji},
                { "yujilist",yuji}
            };


        }


        public Dictionary<string, object> AddSetting(SettingModel model)
        {
            // Type t = typeof(SettingModel);
            string path = HttpContext.Current.Server.MapPath("/App_Data/selfsetting.xml");
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(path);
            // PropertyInfo[] properties = t.GetProperties();
            xmldoc.SelectSingleNode("root").SelectSingleNode("selecttimes").Attributes[0].Value = model.selecttimes;
            xmldoc.SelectSingleNode("root").SelectSingleNode("weekendbili").Attributes[0].Value = model.weekendbili;
            xmldoc.SelectSingleNode("root").SelectSingleNode("mothtimes").Attributes[0].Value = model.mothtimes.ToString();
            xmldoc.Save(path);
            return new Dictionary<string,object>
            {
                { "code","1"}
            };
           
        }
    }
}
