using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BpTools.BpClasses
{
    [XmlType(TypeName = "calculation")]
    public class Calculation
    {
        [XmlAttribute("expression")]
        public string Expression { get; set; }
        [XmlAttribute("stage")]
        public string Stage { get; set; }
    }
}
