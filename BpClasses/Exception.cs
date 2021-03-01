using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BpTools.BpClasses
{
    [XmlType(TypeName = "exception")]
    public class Exception
    {
        [XmlAttribute("type")]
        public string Type { get; set; }
        [XmlAttribute("detail")]
        public string Detail { get; set; }
    }
}
