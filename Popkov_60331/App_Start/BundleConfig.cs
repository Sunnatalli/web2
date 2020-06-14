using System.Web;
using System.Web.Optimization;

namespace Gornaya_80323
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/modernizr-*",
                "~/Scripts/respond.js"));
            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                "~/Content/bootstrap.css", 
                "~/Content/MySite.css"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                                      "~/Scripts/jquery-{version}.js", 
                                      "~/Scripts/jquery-ui-{version}.js", 
                                      "~/Scripts/bootstrap.js", 
                                      "~/Scripts/modernizr-*", 
                                      "~/Scripts/jquery.unobtrusive-ajax.js"));
        }
    }
}
