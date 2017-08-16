using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace BLL
{
   public  class SysLogBll
    {
        public void WriteLog(string objectId, OperationType operationType, LogSatus logSatus, string remark = "")
        {
            SysLogDal.GetInstance().WriteLog(objectId, operationType, logSatus, remark);
        }
    }
}
