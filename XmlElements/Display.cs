using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BpTools.XmlClasses
{
    [XmlType(TypeName = "display")]
    public class Display
    {
        [XmlAttribute("x")]
        public int X { get; set; }
        [XmlAttribute("y")]
        public int Y { get; set; }
        [XmlAttribute("w")]
        public int W { get; set; }
        [XmlAttribute("h")]
        public int H { get; set; }
    }
}
