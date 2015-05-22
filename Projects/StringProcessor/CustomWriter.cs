using BasisObjects;
using log4net;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace StringProcessor
{
    public class CustomWriter : IWritable
    {
        protected ILog Log
        {
            get
            {
                return LogManager.GetLogger(Assembly.GetExecutingAssembly().GetTypes().First());
            }
        }

        protected string PathToSaveStats
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["PathToSaveStats"];
            }
        }

        private string GetRandomPath()
        {
            StringBuilder sbFileName = new StringBuilder(System.DateTime.Now.ToString("ddMMyyHHmmss"));
            sbFileName.Append("_");
            sbFileName.Append(RandomizeService.Text.GetRandomPhrase(5, false));
            sbFileName.Append(".xml");
            string completePath = System.IO.Path.Combine(this.PathToSaveStats, sbFileName.ToString());
            return completePath;
        }

        public void Write(string Text)
        {
            this.Log.Info(Text);
        }

        public void WriteLine(string Text)
        {
            this.Log.Info(Text);
        }

        public void WriteStat(string Key, string Value)
        {
            this.Log.InfoFormat("{0}:{1}");
        }

        public void WriteStats(ITextStatistics Stats, IMessage Message)
        {
            XDocument doc = this.ParseStatsToXML(Stats, Message);
            doc.Save(this.GetRandomPath());
        }

        protected XDocument ParseStatsToXML(ITextStatistics Stats, IMessage Message)
        {
            XDocument doc = new XDocument(
                    new XElement("Message",
                        new XAttribute("PostedDate", Message.PostDate),
                        new XAttribute("Text", Message.Text)
                        )
                );

            foreach (var item in Stats.Stats)
            {
                doc.Root.Add(new XElement(
                        "Stat",
                        new XAttribute("Name", item.Key),
                        new XAttribute("Value", item.Value)
                        )
                    );
            }

            return doc;
        }
    }
}