using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BpToolsLib.XmlClasses
{
    [XmlType(TypeName = "output")]
    public class Output
    {
        [XmlAttribute("type")]
        public string Type { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("narrative")]
        public string Narrative { get; set; }
        [XmlAttribute("stage")]
        public string Stage { get; set; }
    }
}
