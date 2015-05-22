using System.Collections.Generic;

namespace BasisObjects
{
    public interface ITextStatistics
    {
        IDictionary<string, string> Stats { get; }
    }
}