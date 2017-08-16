using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public  class ModuleBll
    {
        public int ModuleAdd(Module model)
        {
            return ModuleDal.GetInstance().ModuleAdd(model);
        }
        public List<Module> GetModuleList()
        {
            return ModuleDal.GetInstance().GetModuleList();
        }
    }
}
