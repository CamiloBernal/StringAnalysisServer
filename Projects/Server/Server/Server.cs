using System.Web.Http.SelfHost;
using WebApiServer.ConsoleUtils;

namespace WebApiServer
{
    public static partial class Server
    {
        public static void StartServer()
        {
            Console.Clear();
            VerifyConfig();

            var config = ServerConfig.ConfigServer();
            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {

                bool serverIsUp = false;

                try
                {
                    server.OpenAsync().Wait();
                    serverIsUp = true;
                }
                catch (System.AggregateException ae)
                {
                    var baseException = ae.GetBaseException();

                    if (baseException != null && baseException is System.ServiceModel.AddressAccessDeniedException)
                    {
                        Console.WriteException("Sorry, there are no permissions to register the port for the server (Default 8080). Please try to open the server with administrative permissions.", true);
                    }
                    else if (baseException != null && baseException is System.ServiceModel.AddressAlreadyInUseException)
                    {
                        Console.WriteException("Sorry, the default port (8080) for the server is already in using by another application. Please check that only has one instance of the server running.", true);
                    }
                }
                catch (System.Exception)
                {
                    Console.WriteException("Sorry, we have encountered an unexpected error when trying to start the server. Please try again.",true);
                }
                if (serverIsUp)
                {
                    HandleStopServer(true);
                    server.CloseAsync().Wait();
                }
            }
        }

        private static void HandleStopServer(bool ClearConsole = false)
        {
            if (ClearConsole)
                Console.Clear();
            Console.WriteLine("The server is running. Processing requests...", MessageType.Info);
            Console.WriteLine("Press 'P' key to stop the server. Note that this action will cancel any requests from any client.", MessageType.Warning);
            System.ConsoleKeyInfo ki = System.Console.ReadKey(true);
            if (ki.Key == System.ConsoleKey.P)
            {
                Console.WriteLine("Are you sure to stop the server? This will cancel any clients request in progress.", MessageType.Error);
                Console.Write("Press 'Y' to stop the server: ", MessageType.Warning);
                System.ConsoleKeyInfo kiS = System.Console.ReadKey();
                if (kiS.Key == System.ConsoleKey.Y)
                {
                    Console.WriteLine();
                    Console.WriteLine("Stopping the server. Please wait.", MessageType.Info);
                    return;
                }
                else
                {
                    HandleStopServer(true);
                }
            }
            else
            {
                HandleStopServer(true);
            }
        }
    }
}