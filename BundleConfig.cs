using System.Collections.Generic;
using System.Web;
using System.Web.Optimization;

namespace PGD.UI.Mvc
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"
                        ));

 
 
            var valBundle = new ScriptBundle("~/bundles/jqueryval").Include(
                    "~/Scripts/jquery.validate.js",
                    "~/Scripts/jspdf.debug.js",
                    "~/Scripts/globalize/globalize.js",
                    "~/Scripts/globalize/cultures/globalize.culture.pt-BR.js",
                    "~/Scripts/jspdf.plugin.autotable.js",
                    "~/Scripts/FileSaver.js",
                    "~/Scripts/tableExport.js",
                    "~/Scripts/jquery.wordexport.js",
                    "~/Scripts/jquery.table2excel.js",
                    "~/Scripts/html2canvas.js",
                    "~/Scripts/jquery.validate.globalize.js", 
                    "~/Scripts/selectize.js",
                    "~/Scripts/jquery.unobtrusive-ajax.min.js",
                    "~/Scripts/jquery-ui.js",
                    "~/Scripts/jquery.maskedinput.js",
                    "~/Scripts/jquery.blockUI.js",
                    "~/Scripts/jquery-datepicker.js"
                    );

            valBundle.Orderer = new AsIsBundleOrderer();

            bundles.Add(valBundle);

             
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/Bootstrap/js/bootstrap.js",
                      "~/Scripts/respond.js"));


            bundles.Add(new ScriptBundle("~/bundles/CGUUtil").Include(
                "~/Scripts/cgu.util.js",
                "~/Scripts/Functions.js"));


            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/bootstrap/css/bootstrap.css",
                      "~/Content/bootstrap/css/bootstrap-theme.min.css",
                      "~/Content/site.css",
                      "~/Content/css/datatables.min.css",
                      "~/Content/css/datepicker2.css",
                      "~/Content/css/selectize.bootstrap3.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
                      "~/Scripts/jquery.inputmask/inputmask.js",
                      "~/Scripts/jquery.inputmask/jquery.inputmask.js",
                      "~/Scripts/jquery.inputmask/inputmask.extensions.js",
                      "~/Scripts/jquery.inputmask/inputmask.date.extensions.js",
                      "~/Scripts/jquery.inputmask/inputmask.numeric.extensions.js"));

        }
    }

    public class AsIsBundleOrderer : IBundleOrderer
    {
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }
    }
}
