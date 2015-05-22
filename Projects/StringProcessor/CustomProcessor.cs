using BasisObjects;
using System.Collections.Generic;

namespace StringProcessor
{
    public class CustomProcessor : ITextAnalizer, IOutputable
    {
        #region Constructors

        public CustomProcessor()
        {
            //Default constructor
        }

        public CustomProcessor(string messageText)
        {
            this.Message.Text = messageText;
        }

        public CustomProcessor(IMessage message)
        {
            this._Message = message;
        }

        #endregion Constructors

        #region Fields

        private IMessage _Message = null;
        private List<BasisObjects.Delegates.Expression> _Expressions = null;
        private CustomStats _Statistics = null;

        #endregion Fields

        public BasisObjects.IMessage Message
        {
            get
            {
                if (this._Message == null)
                {
                    this._Message = new CustomMessage();
                }
                return this._Message;
            }
        }

        public List<BasisObjects.Delegates.Expression> Expressions
        {
            get
            {
                if (this._Expressions == null)
                {
                    this._Expressions = new List<BasisObjects.Delegates.Expression>();
                }

                return this._Expressions;
            }
        }

        public ITextStatistics Statistics
        {
            get
            {
                if (this._Statistics == null)
                {
                    this._Statistics = new CustomStats();
                }
                return this._Statistics;
            }
        }

        public void ProcessMessage()
        {
            foreach (var item in this.Expressions)
            {
                this.Statistics.Stats.Add(item.Invoke(this.Message));
            }
        }

        public void OutputStats(ITextStatistics Stats, IWritable Writer)
        {
            Writer.WriteStats(Stats, this.Message);
        }

        public void OutputStats()
        {
            this.OutputStats(this.Statistics, new CustomWriter());
        }
    }
}