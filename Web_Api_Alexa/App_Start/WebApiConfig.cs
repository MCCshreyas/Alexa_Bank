using System;
using System.Data.SqlClient;
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
                const string ServerName = @"localhost";
                const string Port = "3306";
                const string DatabaseName = "bankapp";
                const string UserName = "root";
                const string Password = "9970209265";

                string connectionString = $@"   server={ServerName};
                                                port={Port};
                                                database={DatabaseName};
                                                username={UserName};
                                                password={Password};";

                var connection = new MySqlConnection(connectionString);
                return connection;
            }
            catch (SqlException e)
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
