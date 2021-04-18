using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib.Generator
{
    public class Font
    {
        BpToolsLib.Font font;

        public Font(BpToolsLib.Font font)
        {
            this.font = font;
        }

        public XmlClasses.Font GetFont()
        {
            XmlClasses.Font bpFont = new XmlClasses.Font();
            bpFont.Family = font.Family;
            bpFont.Size = font.Size;
            bpFont.Style = font.Style;
            bpFont.Color = font.Color;

            return bpFont;
        }
    }
}
