using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools
{
    class InputParameter
    {
        public string Type { get; set; } = "";
        public string Name { get; set; } = "";
        public string Narrative { get; set; } = "";
        public string Stage { get; set; } = "";

        public InputParameter(string type, string name, string narrative, string stage)
        {
            Type = type;
            Name = name;
            Narrative = narrative;
            Stage = stage;
        }
    }
}
