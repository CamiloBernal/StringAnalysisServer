using log4net;
using System.Linq;
using System.Reflection;

namespace WebApiServer.LogUtils
{
    public static class Logger
    {
        public static ILog Log
        {
            get
            {
                return LogManager.GetLogger(Assembly.GetExecutingAssembly().GetTypes().First());
            }
        }

        public static void ConfigureLog()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}