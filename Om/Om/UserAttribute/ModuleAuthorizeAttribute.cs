using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Om.UserAttribute
{
    public class ModuleAuthorizeAttribute: AuthorizeAttribute
    {
        public ModuleAuthorizeAttribute()
        {

        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {

        }
    }
}