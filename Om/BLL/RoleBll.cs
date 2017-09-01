using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
  public   class RoleBll
    {
        public List<Role> GetRoleList()
        {
          return  RoleDal.GetInstance().GetRoleList();
        }
    }
}
