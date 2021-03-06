﻿using System.Web;
using System.Web.Optimization;

namespace E_Commerce
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/vendor/jquery/jquery.min.js",
                        "~/Content/vendor/bootstrap/js/bootstrap.min.js",
                        "~/Content/vendor/metisMenu/metisMenu.min.js",
                        "~/Content/vendor/raphael/raphael.min.js",
                        "~/Content/vendor/morrisjs/morris.min.js",
                        "~/Content/dist/js/sb-admin-2.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
           

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include());

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Content/vendor/metisMenu/metisMenu.min.css",
                      "~/Content/dist/css/sb-admin-2.css",
                      "~/Content/vendor/morrisjs/morris.css",
                      "~/Content/vendor/font-awesome/css/font-awesome.min.css",
                      "~/Content/CustomStyle.css"));
        }
    }
}
