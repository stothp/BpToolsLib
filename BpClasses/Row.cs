using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BpTools.BpClasses
{   
    [XmlType(TypeName = "row")]
    public class Row
    {
        [XmlElement("field")]
        public List<Field> Fields { get; set; }

        [XmlIgnore]
        public bool FieldsSpecified
        {
            get { return (this.Fields != null && this.Fields.Count > 0); }
        }
    }
}
