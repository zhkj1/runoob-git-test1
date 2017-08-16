using DAL;
using DLL;
using MallWCF.DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public  class UserBll
    {
        public DataTable GetPageList(ref JqGridParam jqgridparam)
        {
            return UserDal.GetInstance().GetPageList(ref jqgridparam);
        }
    }
}
