using System;
using System.Threading.Tasks;

namespace Client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Close this window stop server queries");
            int currentRequest = 0;
            while (true)
            {
                Parallel.Invoke(new Client.Consumer.Consumer().PostMessage);
                currentRequest += 1;
                Console.WriteLine("Request:  " + currentRequest.ToString());
            }
        }
    }
}