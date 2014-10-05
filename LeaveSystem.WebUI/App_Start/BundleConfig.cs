using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace LeaveSystem
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles){
            //bundle Bootstrap CSS files
            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap.css",
                         "~/Content/bootstrap-theme.css"));
            //bundle JQuery and related JS files
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.unobtrusive.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            //bundle Bootstrap JS
            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include("~/Scripts/bootstrap.js"));
        }
    }
}