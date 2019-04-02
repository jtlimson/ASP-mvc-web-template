using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApplicationLayout.Filters
{
    /// <summary>
    /// Checks if user is authenticated to access the page
    /// </summary>
    public class Authentication : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");

            var IsAuthenticated = HttpContext.Current.Session["IsAuthenticated"];
            if (IsAuthenticated == null)
                return false;
            else
                return true;
        }
    }
}