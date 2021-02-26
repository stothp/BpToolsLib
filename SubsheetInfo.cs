using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools
{
    class SubSheetInfo : Stage
    {
        public SubSheetInfo(string name) : base(name, "SubSheetInfo")
        {
            DisplayX = -270;
            DisplayY = 30;
            DisplayWidth = 150;
            DisplayHeight = 90;
        }
    }
}
