using System;
using System.Web;
using System.Web.Mvc;


namespace LeaveSystem.Domain.Infrastructure
{
    public class AttributeUserAuth:AuthorizeAttribute
    {
        public AttributeUserAuth()
        {

        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return base.AuthorizeCore(httpContext);
        }
    }
}
