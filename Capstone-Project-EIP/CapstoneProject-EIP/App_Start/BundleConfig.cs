using System.Web;
using System.Web.Optimization;

namespace CapstoneProject_EIP
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*",
                        "~/Content/Template/eventalk/js/modernizr-2.8.3.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/Template/eventalk/style.css",
                      "~/Content/Template/eventalk/css/normalize.css",
                      "~/Content/Template/eventalk/css/bootstrap.min.css",
                      "~/Content/Template/eventalk/css/main.css",
                      "~/Content/Template/eventalk/css/animate.min.css",
                      "~/Content/Template/eventalk/css/font-awesome.min.css",
                      "~/Content/Template/eventalk/css/font/flaticon.css",
                      "~/Content/Template/eventalk/css/meanmenu.min.css",
                      "~/Content/Template/eventalk/css/magnific-popup.css",
                      "~/Content/Template/eventalk/vendor/slider/css/nivo-slider.css",
                      "~/Content/Template/eventalk/vendor/slider/css/preview.css"));
        }
    }
}
