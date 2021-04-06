using BpTools.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.Interpreter
{
    interface ITraversable
    {
        void SetNextStages(BpTools.StageSet stages);
    }
}
