using BasisObjects;
using System.Collections.Generic;

namespace StringProcessor
{
    public class CustomStats : ITextStatistics
    {
        private Dictionary<string, string> _Stats = null;

        public IDictionary<string, string> Stats
        {
            get
            {
                if (this._Stats == null)
                {
                    this._Stats = new Dictionary<string, string>();
                }
                return this._Stats;
            }
        }
    }
}