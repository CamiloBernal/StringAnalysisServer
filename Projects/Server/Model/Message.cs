using System;

namespace WebApiServer.Model
{
    public class Message : BasisObjects.IMessage
    {
        public Message()
        {
            //Default constructor
        }

        public Message(string text)
        {
            this.Text = text;
        }

        public Message(string text, DateTime postDate)
        {
            this.Text = text;
            this.PostDate = postDate;
        }

        public string Text { get; set; }

        public DateTime PostDate { get; set; }
    }
}