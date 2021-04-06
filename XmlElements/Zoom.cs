
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BpTools.XmlClasses
{   
    [XmlType(TypeName = "zoom")]
    public class Zoom
    {
        [XmlAttribute("version")]
        public string Version { get; set; }
        [XmlText]
        public double Value { get; set; }
    }
}
