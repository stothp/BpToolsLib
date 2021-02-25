using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools
{
    class Font
    {
        public string Family { get; set; }
        public int Size { get; set; }
        public string Style { get; set; }
        public string Color { get; set; }

        public Font (string family, int size, string style, string color)
        {
            Family = family;
            Size = size;
            Style = style;
            Color = color;
        }
    }
}
