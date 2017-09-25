using BLL;
using LeaRun.Utilities;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Om.Controllers
{
    public class ApiCauseController : ApiController
    {
        public Dictionary<string, object> CauseAdd(M_CauseSuggestion model)
        {
            Sys_CauseSuggestionBll bll = new Sys_CauseSuggestionBll();
            model.CreateTime = DateTime.Now;
            model.CreateUserId= ManageProvider.Provider.Current().UserId;
            model.CreateUserName = ManageProvider.Provider.Current().Account;
            if (bll.CauseAdd(model) > 0)
            {
                return new Dictionary<string, object>
                       {
                          { "code","1"}
                      };
            }
            else
            {
                    return new Dictionary<string, object>
                       {
                          { "code","0"}
                      };
            }
        }
    }
}
