using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib
{
    public interface IDataNameHolder
    {
        MutableDataNameSet DataNames { get; }
    }
}
