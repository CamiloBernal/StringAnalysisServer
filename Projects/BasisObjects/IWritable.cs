using System;

namespace BasisObjects
{
    public interface IWritable     {
        void Write(string Text);

        void WriteLine(string Text);

        void WriteStat(string Key, string Value);

        void WriteStats(ITextStatistics Stats, IMessage Message);

        
    }
}