using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BpTools.XmlClasses
{
    [XmlType(TypeName = "alert")]
    public class Alert
    {
        [XmlAttribute("expression")]
        public string Expression { get; set; }
    }
}
