using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasisObjects.Delegates
{
    public delegate KeyValuePair<string, string> Expression(IMessage Message);
}
