using ApiService.Helpers;
using BL.Managers.FlightsManagers;
using BL.Managers.StationsManager;
using Common.Interfaces;
using DAL.Repositories.SqlRepositories;
using Newtonsoft.Json;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace ApiService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new Container();
            
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            
            //SimpleInjector registrations.
            container.Register<IFlightsRepository, SqlFlightsRepository>(Lifestyle.Singleton);
            container.Register<IFlightsManager, FlightsManager>(Lifestyle.Singleton);
            container.Register<IFlightsTimeManager, FlightsTimeManager>(Lifestyle.Singleton);
            container.Register<IStationsManager, StationsManager>(Lifestyle.Singleton);
            container.Register<IStationsRepository, SqlStationsRepository>(Lifestyle.Singleton);
            container.Register<IWaitingStationsManager, StationWatingsManager>(Lifestyle.Singleton);
            container.Register<IHubHelper, HubHelper>(Lifestyle.Singleton);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Re‌​ferenceLoopHandling = ReferenceLoopHandling.Ignore;

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
