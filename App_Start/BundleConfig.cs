using System.Web;
using System.Web.Optimization;

namespace Tutorial
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));
            
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Content/AdminLTE/plugins/bootstrap/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/adminlte").Include("~/Content/AdminLTE/dist/js/adminlte.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/AdminLTE/plugins/font-awesome/css/font-awesome.min.css",
                      "~/Content/AdminLTE/plugins/datatables/dataTables.bootstrap4.css",
                      "~/Content/AdminLTE/dist/css/adminlte.css"
                      ));
            
            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
                    "~/Content/AdminLTE/plugins/bootstrap/js/bootstrap.bundle.min.js",
                       "~/Content/AdminLTE/plugins/datatables/jquery.dataTables.js",
                       "~/Content/AdminLTE/plugins/datatables/dataTables.bootstrap4.js",
                       "~/Content/AdminLTE/plugins/slimScroll/jquery.slimscroll.min.js",
                       "~/Content/AdminLTE/plugins/fastclick/fastclick.js"
                       )
                   ) ;

        }
    }
}