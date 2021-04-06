using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BpTools.XmlClasses
{
    [XmlType(TypeName = "view")]
    public class View
    {
        [XmlElement("camerax")]
        public int CameraX { get; set; }
        [XmlElement("cameray")]
        public int CameraY { get; set; }
        [XmlElement("zoom")]
        public Zoom Zoom { get; set; }
    }
}
