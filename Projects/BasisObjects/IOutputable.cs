namespace BasisObjects
{
    public interface IOutputable
    {
        void OutputStats(ITextStatistics Stats, IWritable Writer);

        void OutputStats();
    }
}