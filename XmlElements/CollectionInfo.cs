using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BpToolsLib.XmlClasses
{
    [XmlType(TypeName = "collectioninfo")]
    public class CollectionInfo
    {
        [XmlElement("singlerow")]
        public string Singlerow { get; set; }
        [XmlElement("field")]
        public List<Field> Fields { get; set; } 
    }
}
