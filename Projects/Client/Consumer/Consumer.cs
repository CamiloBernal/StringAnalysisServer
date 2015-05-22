using System;
using System.Net.Http;
using System.Text;

namespace Client.Consumer
{
    public class Consumer
    {
        //static HttpClient client = new HttpClient();

        private System.Net.Http.HttpClient _client = null;

        protected System.Net.Http.HttpClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new System.Net.Http.HttpClient();
                }
                return _client;
            }
        }

        protected string GetMessageText()
        {
            return RandomizeService.Text.GetRandomPhrase(1001);
        }

        public void PostMessage()
        {
            HttpContent contentPost = new StringContent(GetMessageText(), Encoding.UTF8, "application/json");
            using (System.Net.Http.HttpClient Client = new HttpClient())
            {
                try
                {
                    Client.PostAsync("http://localhost:8080/api/message/", contentPost).Wait();
                }
                catch (System.AggregateException ae)
                {
                    var be = ae.GetBaseException();

                    if (be is System.Net.Http.HttpRequestException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Not the endpoint where to be found running the server. Please check that a server listening on port 8080.");
                    }
                }
            }
        }
    }
}