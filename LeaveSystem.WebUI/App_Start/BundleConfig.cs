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

            /**
             *  bundle JS files
             *  
             * */

            //JQuery
            bundles.Add(new ScriptBundle("~/bundles/js/jquery")
                .Include("~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.unobtrusive.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            //Bootstrap
            bundles.Add(new ScriptBundle("~/bundles/js/bootstrap")
                .Include("~/Scripts/bootstrap.js"));

            //JQuery UI
            /*
            bundles.Add(new ScriptBundle("~/bundles/js/jqueryui")
                .Include("~/Scripts/jquery-ui-{version}.js"));
            */

            /**
             *  bundle CSS files
             * 
             * */

            //Bootstrap
            bundles.Add(new StyleBundle("~/content/css/bootstrap")
                .Include("~/Content/bootstrap.css",
                         "~/Content/bootstrap-theme.css"));

            //JQuery UI
            /*
            bundles.Add(new StyleBundle("~/content/css/jqueryui")
                .Include("//code.jquery.com/ui/1.11.1/themes/smoothness/jquery-ui.css"));
            */
        }
    }
}