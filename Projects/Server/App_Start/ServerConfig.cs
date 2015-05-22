using System.Web.Http;
using System.Web.Http.SelfHost;

namespace WebApiServer
{
    public static class ServerConfig
    {
        public const System.Int64 SERVER_PORT = 8080;
        public const string SERVER_HOST_NAME = "localhost";

        public static HttpSelfHostConfiguration ConfigServer()
        {
            HttpSelfHostConfiguration config = new HttpSelfHostConfiguration(string.Format(@"http://{0}:{1}", SERVER_HOST_NAME.ToString(), SERVER_PORT.ToString()));
            config.Routes.MapHttpRoute(
                    "API Default", "api/{controller}/");
            return config;
        }
    }
}