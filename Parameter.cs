using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools
{
    public abstract class Parameter
    {
        public DataType Type { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";

        public Parameter(DataType type, string name, string narrative)
        {
            Type = type;
            Name = name;
            Description = narrative;
        }
    }
}
