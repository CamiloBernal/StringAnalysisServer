using WebApiServer.ConsoleUtils;

namespace WebApiServer
{
    public static partial class Server
    {

        private static void VerifyConfig()
        {
            try
            {
                ValidateServerPaths();

            }
            catch (System.Configuration.ConfigurationErrorsException ce)
            {
                Console.WriteException(ce, true);
                return;
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                if (!CreateStatsFolder())
                    return;
            }
            catch (System.UnauthorizedAccessException)
            {
                Console.WriteException("No suitable to write over statistics output directory permissions were found. Please check and try starting the server again.", true);
                return;
            }
        }


        private static void ValidateServerPaths()
        {
            string PathToSaveStats = System.Configuration.ConfigurationManager.AppSettings["PathToSaveStats"];
            if (System.String.IsNullOrEmpty(PathToSaveStats))
                throw new System.Configuration.ConfigurationErrorsException("Sorry, app.config configuration entry was found to set the path where the results of the statistics are stored. Please check your configuration file (app.config) and set the path where the files are stored.");


            string path = (System.IO.Path.Combine(PathToSaveStats, "ILoveCodeTag.tag"));
            System.IO.File.Create(path);
        }


        private static bool CreateStatsFolder()
        {
            bool vRet = false;
            string PathToSaveStats = System.Configuration.ConfigurationManager.AppSettings["PathToSaveStats"];
            Console.Write(System.String.Format("The statistics output directory set in the configuration file does not exist. The route configured for files is: '{0}' Do you want to create ?. Press 'Y' for the system to automatically create, or any other key to close the server:", PathToSaveStats), MessageType.Warning);
            System.ConsoleKeyInfo ki = System.Console.ReadKey();
            if (ki.Key == System.ConsoleKey.Y)
            {
                try
                {
                    System.IO.Directory.CreateDirectory(PathToSaveStats);
                    vRet = true;
                }
                catch (System.UnauthorizedAccessException)
                {

                    Console.WriteException("You do not have sufficient permissions to create the output directory for statistics. Please review and try again.", true);
                }
            }
            else
            {
                Console.Write(System.Environment.NewLine);
            }
            return vRet;
        }

    }
}