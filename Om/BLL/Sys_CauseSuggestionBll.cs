using DAL;
using DLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
  public   class Sys_CauseSuggestionBll
    {
        public int CauseAdd(Sys_CauseSuggestion model)
        {
            return Sys_CauseSuggestionDal.GetInstance().CauseAdd(model);
        }
        public List<Sys_CauseSuggestion> GetList()
        {
            return Sys_CauseSuggestionDal.GetInstance().GetList();
        }
    }
}
