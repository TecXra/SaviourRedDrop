using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SaviourRedDrop.Models;
using System.Data.Entity;

namespace SaviourRedDrop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private object config;

        public object GlobalConfiguration { get; private set; }

        protected void Application_Start()
        {

            Database.SetInitializer<ApplicationDbContext>(null);
            //      Database.SetInitializer(new UserDbInitializer());
            //          UserDbContext db = new UserDbContext();
            //          db.Database.Initialize(true);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
