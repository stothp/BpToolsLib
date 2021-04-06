using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BpTools.XmlClasses
{
    [XmlType(TypeName = "font")]
    public class Font
    {
        [XmlAttribute("family")]
        public string Family { get; set; }
        [XmlAttribute("size")]
        public int Size { get; set; }
        [XmlAttribute("style")]
        public string Style { get; set; }
        [XmlAttribute("color")]
        public string Color { get; set; }
    }
}
