using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace InductionPush
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
            );

            /*config.Routes.MapHttpRoute(
                name: "MessageReceived",
                routeTemplate: "api/{controller}/{id}/{originator}",
                defaults: new
                {
                    notificationType = RouteParameter.Optional,
                    id = RouteParameter.Optional,
                    originator = RouteParameter.Optional,
                    recipient = RouteParameter.Optional,
                    body = RouteParameter.Optional,
                    type = RouteParameter.Optional,
                    receivedAt = RouteParameter.Optional,
                }
            );
            config.Routes.MapHttpRoute(
                name: "MessageEvent",
                routeTemplate: "api/{controller}/{id}/{eventType}/{occurredat}",
                defaults: new
                {
                    notificationType = RouteParameter.Optional,
                    id = RouteParameter.Optional,
                    eventType = RouteParameter.Optional,
                    occurredAt = RouteParameter.Optional,
                    }
            );
            config.Routes.MapHttpRoute(
                name: "MessageError",
                routeTemplate: "api/{controller}/{id}/{eventType}/{occurredat}",
                defaults: new
                {
                    notificationType = RouteParameter.Optional,
                    id = RouteParameter.Optional,
                    errorType = RouteParameter.Optional,
                    detail = RouteParameter.Optional
                }
            );*/
        }
    }
}
