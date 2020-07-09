using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using Autofac;
using Autofac.Integration.Mvc;
using BGMS_Service.Services;
using BGMS_Service.Services.Interfaces;
using AutoMapper;
using System.Reflection;
using BGMS_Repository.AutoMapperConfig;
using BGMS_Repository.DAL;
using System.Data.Entity;
using Autofac.Integration.WebApi;

namespace BGMS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureContainer();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            builder.RegisterAssemblyModules(typeof(MvcApplication).Assembly);
            #region DependencyInjection

            //AutoMapper
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });

            builder.RegisterInstance<IMapper>(mapConfig.CreateMapper());

            //Types
            builder.RegisterType<GameService>().As<IGameService>().InstancePerDependency();
            builder.RegisterType<StatisticService>().As<IStatisticService>().InstancePerDependency();
            builder.RegisterType<AppDbContext>().As<AppDbContext>().InstancePerRequest();

            #endregion

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
        }
    }
}
