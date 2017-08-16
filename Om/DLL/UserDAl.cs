using MallWCF.DBHelper;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public  class UserDal: RepositoryFactory<User>
    {
        private static UserDal _instance;
        private static object _object = new Object();
        public static UserDal GetInstance()
        {
            if (_instance == null)
            {
                lock (_object)
                {
                    if (_instance == null)
                    {
                        _instance = new UserDal();
                    }
                }
            }
            return _instance;
        }
        private UserDal()
        {

        }
        //获取用户列表
        public DataTable GetPageList(ref JqGridParam jqgridparam)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append(@"select UserId,Account from BaseUser ");
            return Repository().FindTablePageBySql(strSql.ToString(),ref jqgridparam);

        }
    }
}
