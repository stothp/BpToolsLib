using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BpToolsLib.XmlClasses
{
    [XmlType(TypeName = "resource")]
    public class Resource
    {
        [XmlAttribute("object")]
        public string Object { get; set; }
        [XmlAttribute("action")]
        public string Action { get; set; }
    }
}
