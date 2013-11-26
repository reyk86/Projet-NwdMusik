using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using Nwd.BackOffice.Model;
using Nwd.FrontOffice.Model;
using NUnit.Framework;

namespace Senuti
{
    // Remarque : pour obtenir des instructions sur l'activation du mode classique IIS6 ou IIS7, 
    // visitez http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<NwdBackOfficeContext>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<NwdFrontOfficeContext>());

            using (var ctx = new NwdBackOfficeContext())
            {
                ctx.Database.Initialize(true);
            }
            using (var ctx = new NwdFrontOfficeContext())
            {
                ctx.Database.Initialize(true);
            }
        }
    }
}