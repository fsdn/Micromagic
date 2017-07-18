using System.Web;
using System.Web.Optimization;

namespace Micromagic
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            //BundleTable.EnableOptimizations = true;

            #region Common

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/Scripts/jquery-{version}.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/Scripts/bootstrap.js",
                      "~/Content/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Styles/bootstrap.css",
                      "~/Content/Styles/site.css"));

            #endregion

            #region H5

            #region Layout

            bundles.Add(new StyleBundle("~/H5/Styles/Views").Include(
                "~/Content/Thirds/normalize-7.0.0/css/normalize.css",
                "~/Content/Thirds/weui-1.1.1/css/weui.css",
                "~/Content/Thirds/animate-4.0.0/css/animate.css",
                "~/Content/Thirds/materialicons-3.0.1/css/material-icons.css",
                "~/Content/Common/css/DataPool.css",
                "~/Content/Common/css/Common.css",
                "~/Content/Common/css/LayoutH5.css"));
            bundles.Add(new ScriptBundle("~/H5/Scripts/Views").Include(
                "~/Content/Thirds/jquery-3.2.0/js/jquery.js",
                "~/Content/Thirds/angular-1.6.5/js/angular.js",
                "~/Content/Thirds/devicejs-0.2.7/js/device.js",
                "~/Content/Thirds/weui-1.1.1/js/jweixin.js",
                "~/Content/Thirds/weui-1.1.1/js/weui.js",
                "~/Content/Thirds/urljs-2.4.0/js/url.js",
                "~/Content/Common/js/DataPool.js",
                "~/Content/Common/js/Common.js",
                "~/Content/Common/js/LayoutH5.js"));

            #endregion

            #region Magic

            bundles.Add(new StyleBundle("~/H5/Styles/Magic").Include(
                "~/Content/H5/Magic/Magic/Magic.css"));
            bundles.Add(new ScriptBundle("~/H5/Scripts/Magic").Include(
                "~/Content/H5/Magic/Magic/Magic.js"));

            bundles.Add(new StyleBundle("~/H5/Styles/Magic/Index").Include(
                "~/Content/H5/Magic/Magic/Index.css"));
            bundles.Add(new ScriptBundle("~/H5/Scripts/Micro/Index").Include(
                "~/Content/H5/Magic/Magic/Index.js"));

            #endregion

            #region Micro

            bundles.Add(new StyleBundle("~/H5/Styles/Micro").Include(
                "~/Content/H5/Micro/Micro/Micro.css"));
            bundles.Add(new ScriptBundle("~/H5/Scripts/Micro").Include(
                "~/Content/H5/Micro/Micro/Micro.js"));

            bundles.Add(new StyleBundle("~/H5/Styles/Micro/Index").Include(
                "~/Content/H5/Micro/Micro/Index.css"));
            bundles.Add(new ScriptBundle("~/H5/Scripts/Micro/Index").Include(
                "~/Content/H5/Micro/Micro/Index.js"));

            #endregion

            #region Weather

            bundles.Add(new StyleBundle("~/H5/Styles/Weather").Include(
                "~/Content/H5/Weather/Weather/Weather.css"));
            bundles.Add(new ScriptBundle("~/H5/Scripts/Weather").Include(
                "~/Content/H5/Weather/Weather/Weather.js"));

            bundles.Add(new StyleBundle("~/H5/Styles/Weather/Index").Include(
                "~/Content/H5/Weather/Weather/Index.css"));
            bundles.Add(new ScriptBundle("~/H5/Scripts/Weather/Index").Include(
                "~/Content/H5/Weather/Weather/Index.js"));

            #endregion

            #endregion

            #region PC

            #region Layout

            bundles.Add(new StyleBundle("~/PC/Styles/Views").Include(
                "~/Content/Thirds/animate-4.0.0/css/animate.css",
               "~/Content/Thirds/tether-1.3.3/css/tether.css",
               "~/Content/Thirds/bootstrap-3.3.7/css/bootstrap.css",
               "~/Content/Common/css/DataPool.css",
               "~/Content/Common/css/Common.css",
               "~/Content/Common/css/LayoutPC.css"));
            bundles.Add(new ScriptBundle("~/PC/Scripts/Views").Include(
                "~/Content/Scripts/modernizr-*",
                "~/Content/Thirds/jquery-3.2.0/js/jquery.js",
                "~/Content/Thirds/angular-1.6.5/js/angular.js",
                "~/Content/Thirds/bootstrap-3.3.7/js/bootstrap.js",
                "~/Content/Thirds/devicejs-0.2.7/js/device.js",
                "~/Content/Thirds/urljs-2.4.0/js/url.js",
                "~/Content/Common/js/DataPool.js",
                "~/Content/Common/js/Common.js",
                "~/Content/Common/js/LayoutPC.js"));

            #endregion

            #region Home

            bundles.Add(new StyleBundle("~/PC/Styles/Home").Include(
             "~/Content/PC/Home/Home/Home.css"));
            bundles.Add(new ScriptBundle("~/PC/Scripts/Home").Include(
               "~/Content/PC/Home/Home/Home.js"));

            bundles.Add(new StyleBundle("~/PC/Styles/Home/Index").Include(
             "~/Content/PC/Home/Index/Index.css"));
            bundles.Add(new ScriptBundle("~/PC/Scripts/Home/Index").Include(
               "~/Content/PC/Home/Index/Index.js"));

            #endregion

            #endregion
        }
    }
}
