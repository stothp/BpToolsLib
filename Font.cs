using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools
{
    public class Font
    {
        public string Family { get; set; } = "Segoe UI";
        public int Size { get; set; } = 10;
        public string Style { get; set; } = "Regular";
        public string Color { get; set; } = "000000";

        public Font()
        {
        }

        public Font (string family, int size, string style, string color)
        {
            Family = family;
            Size = size;
            Style = style;
            Color = color;
        }
    }
}
