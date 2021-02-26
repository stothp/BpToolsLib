using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools
{
    class End : Stage
    {
        public End(string name) : base(name, "End") { }
        public End() : this("End") { }
        public OutputParameterCollection OutputParameters { get; set; } = new OutputParameterCollection();


    }
}
