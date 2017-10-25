using DAL;
using MallWCF.DBHelper;
using Model;
using Model.ModelView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Web;
using System.Xml;

namespace BLL
{
  public   class M_HitchInfoBll
    {
        public int M_HitchInfoAdd(M_HitchInfo model)
        {
            return M_HitchInfoDal.GetInstance().M_HitchInfoAdd(model);
        }
        public DataTable GetPageList(ref JqGridParam jqgridparam)
        {
            return M_HitchInfoDal.GetInstance().GetPageList(ref jqgridparam);
        }
        //获取场站
        public List<string> GetFactorySationList()
        {
            IDatabase database = DataFactory.Database();
            var ds = database.FindDataSetBySql("SELECT [FactorySation]  FROM[ElectricPower].[dbo].[M_HitchInfo]   group by FactorySation  order by FactorySation");
            List<string> list = new List<string>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                list.Add(ds.Tables[0].Rows[i]["FactorySation"].ToString());
            }
            return list;
        }
        public SettingModel GetSettingModel()
        {
             
            SettingModel SettingModel1 = new SettingModel();
           // Type t = typeof(SettingModel);
            string path = HttpContext.Current.Server.MapPath("/App_Data/selfsetting.xml");
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(path);
           // PropertyInfo[] properties = t.GetProperties();
            SettingModel1.selecttimes = xmldoc.SelectSingleNode("root").SelectSingleNode("selecttimes").Attributes[0].Value;
            SettingModel1.mothtimes = int.Parse(xmldoc.SelectSingleNode("root").SelectSingleNode("mothtimes").Attributes[0].Value);
            SettingModel1.weekendbili = xmldoc.SelectSingleNode("root").SelectSingleNode("weekendbili").Attributes[0].Value;
            SettingModel1.showcount = int.Parse(xmldoc.SelectSingleNode("root").SelectSingleNode("showcount").Attributes[0].Value);
            SettingModel1.daorutime =xmldoc.SelectSingleNode("root").SelectSingleNode("daorutime").Attributes[0].Value;
            SettingModel1.daorudir = xmldoc.SelectSingleNode("root").SelectSingleNode("daorudir").Attributes[0].Value;
            return SettingModel1;
        }
        public string GetSetting(string property)
        {
            string path = HttpContext.Current.Server.MapPath("/App_Data/selfsetting.xml");
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(path);
            return xmldoc.SelectSingleNode("root").SelectSingleNode(property).Attributes[0].Value;
        }

        //获取剩余的数量
        public static int GetRestCount(List<int> list, int index)
        {
            int sum = 0;
           
            for (int i = 0; i < list.Count; i++)
            {
                if (i < index)
                {
                    sum += list[i];
                }
                else {
                    break;
                }
               
            }
            return sum; 
        }
        public static int GetListSum(List<int> list)
        {
            int sum = 0;
            foreach (var item in list)
            {
                sum += item;
            }
            return sum;

        }
           
        

    }
}
