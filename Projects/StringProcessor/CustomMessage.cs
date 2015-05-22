using BasisObjects;
using System;

namespace StringProcessor
{
    public class CustomMessage : IMessage
    {
        public string Text
        {
            get;
            set;
        }

        public DateTime PostDate
        {
            get;
            set;
        }
    }
}