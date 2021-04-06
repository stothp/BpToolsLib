using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools
{
    public class StagePageInfo : Stage
    {
        public StagePageInfo() : base("PageInfo", StageType.SubsheetInfo)
        {
            X = -270;
            Y = 30;
            Width = 150;
            Height = 90;
        }

        public StagePageInfo(string name) : this()
        {
            Name = name;
        }
    }
}
