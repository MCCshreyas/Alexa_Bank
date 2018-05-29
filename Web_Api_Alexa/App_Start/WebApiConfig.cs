using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MySql.Data.MySqlClient;

namespace Web_Api_Alexa
{
    public static class WebApiConfig
    {
        public static MySqlConnection ConnectDb()
        {
            try
            {
                const string connectionString = @"server=localhost;port=3306;database=bankapp;username=root;password=9970209265;";
                
                var conn = new MySqlConnection(connectionString);
                return conn;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
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


            var appxmltypes =
                config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(
                    t => t.MediaType == "application/json");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appxmltypes);



        }
    }
}
