using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using System.Web.Optimization;

using LeaveSystem.WebUI.Infrastructure;
using LeaveSystem.Domain.Entities;
using LeaveSystem.WebUI.Infrastructure.Binders;


namespace LeaveSystem.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //register Ninject for dependencies
            DependencyResolver.SetResolver(new NinjectDependencyResolver());

            //register a customised Model Binder
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());

            //register bundles to import JS and CSS files
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
