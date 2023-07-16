using Autofac;
using Autofac.Integration.Mvc;
using LinakisDigitalNews.Models;
using LinakisDigitalNews.Service;
using LinakisDigitalNewsApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;



namespace LinakisDigitalNews
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            var container = ContainerConfig.Configure();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            using (var scope = container.BeginLifetimeScope())
            {
                var fillArticlesService = scope.Resolve<IFillArticlesService>();
                fillArticlesService.FillArticlesFromRequest();
            }
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
