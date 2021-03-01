using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BpTools.BpClasses
{
    [XmlType(TypeName = "condition")]
    public class Condition
    {
        [XmlAttribute("narrative")]
        public string Narrative { get; set; }
    }
}
