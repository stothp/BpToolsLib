using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BpTools.XmlClasses
{
    [XmlType(TypeName = "subsheet")]
    public class Subsheet
    {
        [XmlAttribute("subsheetid")]
        public string SubsheetId { get; set; }
        [XmlAttribute("type")]
        public string Type { get; set; }
        [XmlAttribute("published")]
        public string Published { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("view")]
        public View View { get; set; }


    }
}
