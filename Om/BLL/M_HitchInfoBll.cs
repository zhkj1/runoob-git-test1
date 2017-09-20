using DAL;
using MallWCF.DBHelper;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
