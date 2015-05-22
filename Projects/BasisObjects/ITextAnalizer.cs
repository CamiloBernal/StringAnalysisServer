using System.Collections.Generic;

namespace BasisObjects
{
    public interface ITextAnalizer : IOutputable
    {
        IMessage Message { get; }

        List<Delegates.Expression> Expressions { get; }

        ITextStatistics Statistics { get; }

        void ProcessMessage();
    }
}