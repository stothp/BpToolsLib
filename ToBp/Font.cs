using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.ToBp
{
    public static class Font
    {
        public static BpClasses.Font GetXmlObj(BpTools.Font font)
        {
            BpClasses.Font xmlObj = new BpClasses.Font();
            xmlObj.Family = font.Family;
            xmlObj.Size = font.Size;
            xmlObj.Style = font.Style;
            xmlObj.Color = font.Color;

            return xmlObj;
        }
    }
}
