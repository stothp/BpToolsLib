using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BpTools.XmlClasses
{
    [XmlType(TypeName = "input")]
    public class Input
    {
        [XmlAttribute("type")]
        public string Type { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("narrative")]
        public string Narrative { get; set; }
        [XmlAttribute("stage")]
        public string Stage { get; set; }
        [XmlAttribute("expr")]
        public string Expr { get; set; }
    }
}
