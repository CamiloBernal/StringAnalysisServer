using System;

namespace BasisObjects
{
    public interface IMessage
    {
        string Text { get; set; }

        DateTime PostDate { get; set; }
    }
}