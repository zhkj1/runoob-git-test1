using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ModuleOperateBll
    {
        public int ModuleOperateAdd(ModuleOperate model)
        {
            return ModuleOperateDal.GetInstance().ModuleOperateAdd(model);
        }
        public List<ModuleOperate> GetModuleOperateListByModuleId(int moduleid)
        {
            return ModuleOperateDal.GetInstance().GetModuleOperateListByModuleId(moduleid);
        }

    }
}
