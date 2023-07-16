using Autofac;
using Autofac.Integration.Mvc;
using LinakisDigitalNews.Context;
using LinakisDigitalNews.Repositories;
using LinakisDigitalNews.Service;
using LinakisDigitalNewsApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinakisDigitalNews
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();

            //CONTROLLERS
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //DBCONTEXT
            builder.RegisterType<LinakisDigitalNewsContext>().InstancePerLifetimeScope();
            //REPOSITORIES
            builder.RegisterType<PageRepository>().As<IPageRepository>();
            builder.RegisterType<ArticleRepository>().As<IArticleRepository>();
            //UNITOFWORK
            builder.RegisterType<UnitOfWork<LinakisDigitalNewsContext>>().As<IUnitOfWork<LinakisDigitalNewsContext>>();
            //APIS
            builder.RegisterType<NewsApiRequest>().As<INewsApiRequest>();
            //SERVICES
            builder.RegisterType<FillArticlesService>().As<IFillArticlesService>();

            return builder.Build();
        }


    }
}