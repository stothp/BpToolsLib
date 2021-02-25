using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools
{
    class Start : Stage, ILeavable
    {
        public string OnSuccess { get; set; } = "";
        public InputParameterCollection InputParameters { get; set; } = new InputParameterCollection();

        public Start () : base ("Start", "Start")
        {
   
        }

        public Start(string name) : base(name, "Start")
        {

        }
    }
}
