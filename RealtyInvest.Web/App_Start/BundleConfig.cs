using System.Web.Optimization;

namespace RealtyInvest.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/moment.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.min.js",
                        "~/Scripts/angular-route.min.js",
                        "~/Scripts/angular-route.min.js",
                        "~/Scripts/angular-resource.min.js",
                        "~/Scripts/angular-loader.min.js",
                        "~/Scripts/angular-animate.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular-ui").Include(
                        "~/Scripts/angular-ui/ui-bootstrap.min.js",
                        "~/Scripts/angular-ui/ui-bootstrap-tpls.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular-app").Include(
                        "~/Scripts/app/app.module.js"));

            bundles.Add(new ScriptBundle("~/bundles/countrylist-json").Include(
                        "~/Scripts/countriesToCities.json"));

            bundles.Add(new ScriptBundle("~/bundles/angular-main").Include(
                        "~/Scripts/app/login-angular.js",
                        "~/Scripts/app/search-controller.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/uobtrusivejs").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.min.js",
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin").Include(
                        "~/Scripts/admin.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin-forecast").Include(
                        "~/Scripts/Chart.min.js",
                        "~/Scripts/app/forecast-controller.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin-editestate").Include(
                        "~/Scripts/angular-google-maps.min.js",
                        "~/Scripts/angular-google-maps-street-view.min.js",
                        "~/Scripts/lodash.core.min.js",
                        "~/Scripts/lodash.min.js",
                        "~/Scripts/app/realestate-controller.js"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // используйте средство построения на сайте http://modernizr.com, чтобы выбрать только нужные тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/bootstrap-theme.min.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css", 
                      "~/Content/themes/jquery-ui.min.css",
                      "~/Content/themes/jquery-ui.theme.min.css"));
        }
    }
}
