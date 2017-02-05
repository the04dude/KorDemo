using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Http;
using Kor.Core;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.WebApi;

namespace Kor.Web
{
    public static class WebApiConfig
    {

        private static readonly Bootstrapper kernelBootstrapper = new Bootstrapper();

        public static void RegisterNinject()
        {
            kernelBootstrapper.Initialize(() =>
            {
                var kernel = new StandardKernel();
                kernel.Bind<IDataProvider>().To<ConcreteDataProvider>();
                return kernel;
            });
        }

        public static void Register(HttpConfiguration config)
        {
            RegisterNinject();

            // Web API configuration and services

            config.DependencyResolver = new NinjectDependencyResolver(kernelBootstrapper.Kernel);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Routes.MapHttpRoute(
            //    name: "RootWebApiRoute",
            //    routeTemplate: "{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.Routes.MapHttpRoute(
                name: "RootWebApiRoute_Cars",
                routeTemplate: "cars",
                defaults: new { id = RouteParameter.Optional, Action= "get", Controller="cars" }
            );
            config.Routes.MapHttpRoute(
                name: "RootWebApiRoute_Hondas",
                routeTemplate: "hondas",
                defaults: new { id = RouteParameter.Optional, Action = "get", Controller = "hondas" }
            );
        }
    }
}
