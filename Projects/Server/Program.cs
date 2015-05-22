using WebApiServer.ConsoleUtils;
using WebApiServer.LogUtils;

namespace WebApiServer
{
    public static partial class Server
    {
        private static void Main(string[] args)
        {
            Logger.ConfigureLog();
            Server.StartServer();
            Console.WriteLine("Goodbye!!!!", MessageType.Info);
        }
    }
}