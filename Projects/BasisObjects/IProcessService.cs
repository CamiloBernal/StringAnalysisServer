using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasisObjects
{
    public interface IProcessService
    {

        IMessage Message { get; }

        void ProcessMessage(IMessage Message);
        void ProcessMessage();



    }
}
