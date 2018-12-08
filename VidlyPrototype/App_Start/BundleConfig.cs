using System.Web;
using System.Web.Optimization;

namespace VidlyPrototype
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootbox.js",
                        "~/Scripts/DataTables/jquery.datatables.js",
                        "~/Scripts/DataTables/datatables.bootstrap4.js",
                        "~/Scripts/typeahead.bundle.js",
                        "~/Scripts/toastr.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                     "~/Scripts/custom.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/styles.css",
                      "~/Content/DataTables/css/datatables.bootstrap4.css",
                      "~/Content/fontawesome/all.css",
                      "~/Content/typeahead.css",
                      "~/Content/toastr.css"));
        }
    }
}
