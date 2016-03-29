using System.Web;
using System.Web.Optimization;

namespace Epam.TodoManager.Presentation.WebMvc
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/angular.min.js",
                "~/Scripts/angular-route.min.js",
                "~/Scripts/angular-resource.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular-oauth").Include(
                "~/bower_components/angular-cookies/angular-cookies.min.js",
                "~/bower_components/query-string/query-string.js",
                "~/bower_components/angular-oauth2/dist/angular-oauth2.js"));

            bundles.Add(new ScriptBundle("~/bundles/appScripts")
                .IncludeDirectory("~/Scripts/app", "*.js", true));

            bundles.Add(new ScriptBundle("~/bundles/webapp").Include(
                "~/Scripts/jquery-2.2.1.js",
                "~/Scripts/jquery-ui.min.js",
                "~/Scripts/angular.js",
                "~/Scripts/angular-route.min.js",
                "~/Scripts/sortable.js"));

            bundles.Add(new ScriptBundle("~/bundles/webapp-custom").Include(
                    "~/Scripts/app/webapp/app.js",
                    "~/Scripts/app/services/listService.js",
                    "~/Scripts/app/services/taskService.js",
                    "~/Scripts/app/services/accountService.js",
                    "~/Scripts/app/services/dataService.js",
                    //"~/Scripts/app/webapp/controllers/appController.js",
                    //"~/Scripts/app/webapp/controllers/listsController.js",
                    //"~/Scripts/app/webapp/controllers/tasksController.js",
                    //"~/Scripts/app/webapp/controllers/detailsController.js",
                    //"~/Scripts/app/webapp/controllers/routeControllers.js",
                    //"~/Scripts/app/webapp/controllers/addListController.js",
                    //"~/Scripts/app/webapp/controllers/editListController.js",
                    //"~/Scripts/app/webapp/controllers/accountController.js",
                    "~/Scripts/app/webapp/directives.js").
                    IncludeDirectory("~/Scripts/app/webapp/controllers", "*.js", false));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/css/login").Include(
                "~/Content/styles/account/common.css",
                "~/Content/styles/account/login.css"));

            bundles.Add(new StyleBundle("~/Content/css/signup").Include(
               "~/Content/styles/account/common.css",
               "~/Content/styles/account/signup.css"));

            bundles.Add(new StyleBundle("~/Content/css/webapp").Include(
                "~/Content/styles/webapp/webapp.css",
                "~/Content/styles/webapp/jquery-ui.min.css",
                "~/Content/styles/webapp/jquery-ui.structure.min.css"));
        }
    }
}
