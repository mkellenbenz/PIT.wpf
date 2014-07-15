﻿using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace PIT.REST
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ConfigureRouting(config);
            ConfigureFormatters(config);
        }

        private static void ConfigureRouting(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Projects",
                routeTemplate: "api/projects/{id}",
                defaults: new {controller = "projects", id = RouteParameter.Optional}
                );

            config.Routes.MapHttpRoute(
                name: "Issues",
                routeTemplate: "api/issues/{id}",
                defaults: new { controller = "issues", id = RouteParameter.Optional }
                );
        }

        private static void ConfigureFormatters(HttpConfiguration config)
        {
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}