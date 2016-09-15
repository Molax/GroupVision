using System.Web;
using System.Web.Optimization;

namespace GroupVisao.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region | System Bundle |
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            #endregion

            #region | Theme AutoEscola - JS |
            bundles.Add(new ScriptBundle("~/bundles/core").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui.custom.min.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/modernizr-2.6.2-respond-1.1.0.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/page-level").Include(
                        "~/Scripts/google-code-prettify/prettify.js",
                        "~/Scripts/perfectscrollbar/perfect-scrollbar.jquery.min.js",
                        "~/Scripts/iCheck/icheck.min.js",
                        "~/Scripts/bootstrap-select/bootstrap-select.min.js",
                        "~/Scripts/fullscreen/jquery.fullscreen-min.js"));
            bundles.Add(new ScriptBundle("~/bundles/plugins").Include(
                        "~/Scripts/materialRipple/jquery.materialRipple.js",
                        "~/Scripts/snackbar/jquery.snackbar.js",
                        "~/Scripts/toasts/jquery.toasts.js",
                        "~/Scripts/speedDial/jquery.speedDial.js",
                        "~/Scripts/circularProgress/jquery.circularProgress.js",
                        "~/Scripts/linearProgress/jquery.linearProgress.js",
                        "~/Scripts/subheader/jquery.subheader.js",
                        "~/Scripts/simplePieChart/jquery.simplePieChart.js"));
            bundles.Add(new ScriptBundle("~/bundles/theme").Include(
                        "~/Scripts/common.min.js",
                        "~/Scripts/jquery.mask.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/categoria").Include(
                        "~/Scripts/categoria.js"));
            bundles.Add(new ScriptBundle("~/bundles/agenda").Include(
                        "~/Scripts/agenda.js"));
            bundles.Add(new ScriptBundle("~/bundles/aulaaluno").Include(
                        "~/Scripts/aulaaluno.js"));
            bundles.Add(new ScriptBundle("~/bundles/regra").Include(
                        "~/Scripts/regra.js"));
            bundles.Add(new ScriptBundle("~/bundles/certificado").Include(
                        "~/Scripts/certificado.js"));
            bundles.Add(new ScriptBundle("~/bundles/aulamarcada").Include(
                        "~/Scripts/aulamarcada.js"));
            bundles.Add(new ScriptBundle("~/bundles/login").Include(
                        "~/Scripts/login.js"));
            bundles.Add(new ScriptBundle("~/bundles/veiculo").Include(
                        "~/Scripts/veiculo.js"));
            bundles.Add(new ScriptBundle("~/bundles/diabloqueado").Include(
                        "~/Scripts/diabloqueado.js"));
            bundles.Add(new ScriptBundle("~/bundles/horario").Include(
                        "~/Scripts/horario.js"));
            bundles.Add(new ScriptBundle("~/bundles/dia").Include(
            "~/Scripts/dia.js"));
            bundles.Add(new ScriptBundle("~/bundles/instrutor").Include(
            "~/Scripts/instrutor.js"));
            bundles.Add(new ScriptBundle("~/bundles/empresa").Include(
            "~/Scripts/empresa.js"));
            bundles.Add(new ScriptBundle("~/bundles/usuario").Include(
            "~/Scripts/usuario.js"));
            bundles.Add(new ScriptBundle("~/bundles/DataTable").Include(
                        "~/Scripts/DataTables/js/jquery.dataTables.min.js",
                        "~/Scripts/DataTables/js/dataTables.bootstrap.min.js"));
            #endregion

            #region | Theme AutoEscola - CSS |
            bundles.Add(new StyleBundle("~/Content/core").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/theme.css",
                      "~/Content/prettify-tomorrow.css"));
            #endregion
        }
    }
}
