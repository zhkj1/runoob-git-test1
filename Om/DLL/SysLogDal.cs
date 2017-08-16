using LeaRun.Utilities;
using MallWCF.DBHelper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace DAL
{
    public  class SysLogDal: RepositoryFactory<SysLog>
    {

        private static SysLogDal _instance;
        private static object _object = new Object();
        public static SysLogDal GetInstance()
        {
            if (_instance == null)
            {
                lock (_object)
                {
                    if (_instance == null)
                    {
                        _instance = new SysLogDal();
                    }
                }
            }
            return _instance;
        }
        private SysLogDal()
        {

        }
        public SysLog SysLog = new SysLog();
        //写入日志
        public void WriteLog(string  objectId, OperationType operationType,LogSatus logSatus , string remark = "")
       {
            SysLog.ObjectId = objectId;
            SysLog.LogType = (int)logSatus;
            if (ManageProvider.Provider.IsOverdue())
            {
                SysLog.IPAddress = ManageProvider.Provider.Current().IPAddress;
                SysLog.IPAddressName = ManageProvider.Provider.Current().IPAddressName;
                SysLog.CreateUserId = ManageProvider.Provider.Current().UserId;
                SysLog.CreateUserName = ManageProvider.Provider.Current().Account;
            }
            if (CookieHelper.GetCookie("ModuleId") != "")
            {
                SysLog.ModuleId = int.Parse(DESEncrypt.Decrypt(CookieHelper.GetCookie("ModuleId")));
            }
            SysLog.CreateTime = DateTime.Now;
            SysLog.Remark = remark;
            SysLog.Status = (int)logSatus;
            var task = Task.Factory.StartNew(() =>
            {
                Repository().Insert(SysLog);
            });

        }
    }
}
