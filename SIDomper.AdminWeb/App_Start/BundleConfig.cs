using System.Web.Optimization;
using WebHelpers.Mvc5;

namespace SIDomper.AdminWeb.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/Bundles/css")
                .Include("~/Content/css/bootstrap.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/bootstrap-select.css")
                .Include("~/Content/css/bootstrap-datepicker3.min.css")
                .Include("~/Content/css/select2/select2.css")
                .Include("~/Content/css/font-awesome.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/icheck/blue.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/AdminLTE.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/skins/skin-blue.css"));

            bundles.Add(new ScriptBundle("~/Bundles/js")
                .Include("~/Content/js/plugins/jquery/jquery-3.3.1.js")
                .Include("~/Content/js/plugins/bootstrap/bootstrap.js")
                .Include("~/Content/js/plugins/fastclick/fastclick.js")
                .Include("~/Content/js/plugins/slimscroll/jquery.slimscroll.js")
                .Include("~/Content/js/plugins/bootstrap-select/bootstrap-select.js")
                .Include("~/Content/js/plugins/moment/moment.js")
                .Include("~/Content/js/plugins/datepicker/bootstrap-datepicker.js")
                .Include("~/Content/js/plugins/icheck/icheck.js")
                .Include("~/Content/js/plugins/validator.js")
                .Include("~/Content/js/plugins/inputmask/jquery.inputmask.bundle.js")
                .Include("~/Content/js/plugins/mask/jquery.mask.js")
                .Include("~/Content/js/adminlte.js")
                .Include("~/Content/js/plugins/jquery-validate/jquery.validate.js")
                .Include("~/Content/js/plugins/jquery-validate/jquery.validate.unobtrusive.js")
                .Include("~/Content/js/plugins/vue/vue.js")
                .Include("~/Content/js/plugins/mask/jquery.mask.min.js")
                .Include("~/Content/js/plugins/select2/select2.js")
                .Include("~/Content/js/init.js")
                .Include("~/Content/js/mascaras.js")
                .Include("~/Content/js/methods_pt.js")

                .Include("~/Content/js/plugins/inputmask/inputmask.js")
                .Include("~/Content/js/plugins/mask/mascaras.js")
                .Include("~/Content/js/plugins/inputmask/jquery.inputmask.js")
                .Include("~/Content/js/plugins/inputmask/inputmask.extensions.js")
                .Include("~/Content/js/plugins/inputmask/inputmask.date.extensions.js")
                .Include("~/Content/js/plugins/inputmask/inputmask.numeric.extensions.js")
                .Include("~/Content/js/plugins/jquery/jquery-validate/jquery.validate.custom.pt-br")

                );

            //bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
            //~/Scripts/Inputmask/dependencyLibs/inputmask.dependencyLib.js",  //if not using jquery
            //"~/Scripts/Inputmask/inputmask.js",
            //"~/Scripts/Inputmask/jquery.inputmask.js",
            //"~/Scripts/Inputmask/inputmask.extensions.js",
            //"~/Scripts/Inputmask/inputmask.date.extensions.js",
            //and other extensions you want to include
            //"~/Scripts/Inputmask/inputmask.numeric.extensions.js"));

            //bundles.Add(
            //   new ScriptBundle("~/bundles/validations_pt-br")
            //       .Include(
            //           "~/Scripts/jquery.validate.custom.pt-br*"));

#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}
