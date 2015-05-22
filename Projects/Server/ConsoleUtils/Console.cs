using System;

namespace WebApiServer.ConsoleUtils
{
    public enum MessageType
    {
        Error, Info, Warning
    }

    public static class Console
    {
        public static void Write(string Message, MessageType Type = MessageType.Info)
        {
            Write(Message, Type, false);
        }

        public static void WriteLine(string Message, MessageType Type = MessageType.Info)
        {
            Write(Message, Type, true);
        }

        public static void WriteLine()
        {
            Console.WriteLine(Environment.NewLine);
        }


        public static void WriteException(System.Exception ex, bool ShutdownServer = false)
        {
            if (ShutdownServer)
                Clear();

            Console.WriteLine(ex.Message, MessageType.Error);
            if (ShutdownServer)
            {
                Console.WriteLine("Please press a key to exit.", MessageType.Info);
                System.Console.ReadKey();
            }            
        }


        public static void WriteException(string Message, bool ShutdownServer = false)
        {
            if (ShutdownServer)
                Clear();
            Console.WriteLine(Message, MessageType.Error);
            if (ShutdownServer)
            {
                Console.WriteLine("Please press a key to exit.", MessageType.Info);
                System.Console.ReadKey();
            }
        }



        private static void Write(string Message, MessageType Type = MessageType.Info, bool NewLine = true)
        {
            System.ConsoleColor color = ConsoleColor.Black;
            switch (Type)
            {
                case MessageType.Error:
                    color = ConsoleColor.Red;
                    break;

                case MessageType.Info:
                    color = ConsoleColor.DarkCyan;
                    break;

                case MessageType.Warning:
                    color = ConsoleColor.DarkYellow;
                    break;
            }
            System.Console.ForegroundColor = color;
            if (NewLine)
            {
                System.Console.WriteLine(Message);
            }
            else
            {
                System.Console.Write(Message);
            }
        }

        


        public static void Clear()
        {
            System.Console.Clear();
            System.Console.Title = "String Analysis Server";
        }
    }
}