using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace Maxe.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            
            // Make the api response JSON and not XML
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Allow any origin to call the api for now
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "EntriesApi",
                routeTemplate: "api/Entries/{id}",
                defaults: new { id = RouteParameter.Optional, controller = "Entries" }
            );

            config.Routes.MapHttpRoute(
                name: "ExamineesApi",
                routeTemplate: "api/Examinees/{id}",
                defaults: new { id = RouteParameter.Optional, controller = "Examinees" }
            );

            config.Routes.MapHttpRoute(
                name: "ExamsApi",
                routeTemplate: "api/Exams/{id}",
                defaults: new { id = RouteParameter.Optional, controller = "Exams" }
            );

            config.Routes.MapHttpRoute(
                name: "ExamSectionsApi",
                routeTemplate: "api/ExamSections/{id}/{action}",
                defaults: new { id = RouteParameter.Optional, controller = "ExamSections", action = "GetExamSection" }
            );

            config.Routes.MapHttpRoute(
                name: "QuestionsApi",
                routeTemplate: "api/Questions/{id}",
                defaults: new { id = RouteParameter.Optional, controller = "Questions" }
            );

            config.Routes.MapHttpRoute(
                name: "QuestionTypesApi",
                routeTemplate: "api/QuestionTypes/{id}",
                defaults: new { id = RouteParameter.Optional, controller = "QuestionTypes" }
            );
        }
    }
}
