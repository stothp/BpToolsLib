using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BpTools.XmlClasses
{
    [XmlType(TypeName = "endpoint")]
    public class Endpoint
    {
        [XmlAttribute("narrative")]
        public string Narrative { get; set; }
    }
}
