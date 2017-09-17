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
        public Sys_CauseSuggestion GetModel(int id)
        {
            return Sys_CauseSuggestionDal.GetInstance().GetModel(id);
        }
        public int Sys_CauseSuggestionEdit(Sys_CauseSuggestion model)
        {
            return Sys_CauseSuggestionDal.GetInstance().Sys_CauseSuggestionEdit(model);
        }
        public int CauseDel(int id)
        {
            return Sys_CauseSuggestionDal.GetInstance().CauseDel(id);
        }
        public List<Sys_CauseSuggestion> GetModelList(string ids,int type)
        {
            return Sys_CauseSuggestionDal.GetInstance().GetModelList(ids,type);
        }
      

    }
}
