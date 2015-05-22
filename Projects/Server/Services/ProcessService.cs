using BasisObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WebApiServer.Services
{
    public class ProcessService : IProcessService
    {
        public ProcessService()
        {
            //Default constructor
        }

        public ProcessService(IMessage message)
        {
            this._Message = message;
        }

        private IMessage _Message = null;

        public void ProcessMessage(BasisObjects.IMessage Message)
        {
            StringProcessor.CustomProcessor sp = new StringProcessor.CustomProcessor(Message);
            //Palabras terminadas en 'n'
            sp.Expressions.Add(x => new KeyValuePair<string, string>("Palabras terminadas en n",
                (
                    x.Text.Split(' ').Count(y => y.EndsWith("n")) +
                    x.Text.Split('.').Count(y => y.EndsWith("n")) +
                    x.Text.Split(',').Count(y => y.EndsWith("n")) +
                    x.Text.Split(new string[] { "\n" }, StringSplitOptions.None).Count(y => y.EndsWith("n"))
                ).ToString()));
            //Oraciones de más de 15 palabras
            sp.Expressions.Add(x => new KeyValuePair<string, string>("Oraciones con más de 15 palabras",
                    Regex.Split(x.Text, @"\.\ ").ToList().Count(y => y.Split(new string[] { " " }, StringSplitOptions.None).Count() > 15).ToString()
                    ));
            //Número de parrafos
            sp.Expressions.Add(x => new KeyValuePair<string, string>("Número de parrafos",
                    Regex.Split(x.Text, @"\.\n").Length.ToString()
                    ));
            //Contar Alfanumérico != n
            sp.Expressions.Add(x => new KeyValuePair<string, string>("Caracteres alfanuméricos distintos a n o N",
                        x.Text.ToCharArray().ToList().Where(c => !(new List<string> { "n", "N", " ", ".", "," }).Contains(c.ToString())).Count().ToString()
                    ));

            //Peso en Bytes del mensaje (Adicional para control)
            sp.Expressions.Add(x => new KeyValuePair<string, string>("Peso en Bytes del mensaje (Adicional para control)",
                         System.Text.ASCIIEncoding.ASCII.GetByteCount(x.Text).ToString()
                    ));

            sp.ProcessMessage();
            sp.OutputStats();
        }

        public IMessage Message
        {
            get
            {
                if (this._Message == null)
                    this._Message = new Model.Message();
                return this._Message;
            }
        }

        public void ProcessMessage()
        {
            this.ProcessMessage(this.Message);
        }
    }
}