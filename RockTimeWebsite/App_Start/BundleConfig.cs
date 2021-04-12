using System.Web;
using System.Web.Optimization;


namespace RockTimeWebsite.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts.js")
                .Include(
                        "~/Scripts/jquery-1.8.2.min.js",
                         "~/Scripts/bootstrap.min.js"
                        ));

            bundles.Add(new StyleBundle("~/website.css")
                .Include("~/Content/bootstrap.min.css"));

           
        }
    }
}