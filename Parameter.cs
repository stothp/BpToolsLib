using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools
{
    public class Parameter
    {
        public DataType Type { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string StageName { get; set; } = "";

        public Parameter(DataType type, string name, string narrative, string stage)
        {
            Type = type;
            Name = name;
            Description = narrative;
            StageName = stage;
        }
    }
}
