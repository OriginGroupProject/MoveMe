﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json.Serialization;

namespace MoveMe.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // enable error reporting
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            //enable cors
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            //camel case
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();

            //xml formatting
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
