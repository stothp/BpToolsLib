using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BpTools.BpClasses
{
    public class Field
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("type")]
        public string Type { get; set; }
        [XmlAttribute("namespace")]
        public string Namespace { get; set; }
        [XmlAttribute("value")]
        public string Value { get; set; }
    }
}
