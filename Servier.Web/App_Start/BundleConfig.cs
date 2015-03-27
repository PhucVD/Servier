using System.Web;
using System.Web.Optimization;

namespace Servier
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //javascript
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.10.2.min.js",
                        "~/Scripts/jquery-ui-1.9.2.custom.min.js",
                        "~/Scripts/jquery-migrate-1.2.1.min.js",
                        "~/Scripts/jquery.nicescroll.js",
                        "~/Scripts/jquery.validate.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
                      "~/Scripts/datatable/jquery.dataTables.js",
                      "~/Scripts/datatable/editable-table.js",
                      "~/Scripts/datatable/dt-bootstrap.js"));


            bundles.Add(new ScriptBundle("~/bundles/datepicker").Include(
                      "~/Scripts/datepicker/bootstrap-datepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                      "~/Scripts/scripts.js"));
            bundles.Add(new ScriptBundle("~/bundles/ie-9").Include(
                      "~/Scripts/html5shiv.js"));

            //CSS
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/style.css",
                      "~/Content/css/style-responsive.css"));
        }
    }
}
