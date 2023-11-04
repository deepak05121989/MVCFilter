using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Filters;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace MVCFilter.Auth
{
    public class AuthAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        object userName = null;
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            userName = filterContext.HttpContext.Session["user"];
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (userName == null || (!userName.ToString().Equals(filterContext.HttpContext.Session["user"].ToString())))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}