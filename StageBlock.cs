using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpTools
{
    public class StageBlock : Stage
    {

        public StageBlock() : base("Block", Stage.StageType.Block) {
            Font.Color = "7FB2E5";
        }

        public StageBlock(string name) : this() {
            Name = name;
        }

        public StageBlock(string name, string color) : this(name)
        {
            Font.Color = color;
        }

    }
}
