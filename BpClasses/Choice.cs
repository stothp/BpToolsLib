using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BpTools.BpClasses
{
    [XmlType(TypeName = "choice")]
    public class Choice
    {
        [XmlAttribute("expression")]
        public string Expression { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("distance")]
        public int Distance { get; set; }
        [XmlElement("ontrue")]
        public string OnTrue { get; set; }
    }
}
