using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BpToolsLib.XmlClasses
{
    [XmlType(TypeName = "initialvalue")]
    public class InitialValue
    {
        [XmlElement("singlerow")]
        public string Singlerow { get; set; }
        [XmlElement("row")]
        public List<Row> Rows { get; set; }
        [XmlText]
        public string Value { get; set; }
        
        [XmlIgnore]
        public bool RowsSpecified
        {
            get { return (this.Rows != null && this.Rows.Count > 0); }
        }
    }
}
