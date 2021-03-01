using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools
{
    public class PageInformation : Stage
    {
        public PageInformation(string name) : base(name, StageType.SubsheetInfo)
        {
            X = -270;
            Y = 30;
            Width = 150;
            Height = 90;
        }
    }
}
