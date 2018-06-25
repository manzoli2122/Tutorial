using System.Web;
using System.Web.Optimization;

namespace Tutorial
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
              //        "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                     "~/Content/AdminLTE/plugins/bootstrap/js/bootstrap.js"));


            bundles.Add(new ScriptBundle("~/bundles/adminlte").Include(
                     "~/Content/AdminLTE/dist/js/adminlte.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      
                      //"~/Content/bootstrap.css",
                      "~/Content/AdminLTE/plugins/bootstrap/css/bootstrap.css",
                      "~/Content/AdminLTE/plugins/font-awesome/css/font-awesome.min.css",
                    //  "~/Content/AdminLTE/dist/css/adminlte.css",
                      "~/Content/AdminLTE/dist/css/adminlte.css"
                      ));
        }
    }
}
