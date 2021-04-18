using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BpToolsLib.XmlClasses
{
    [XmlType(TypeName = "process")]
    public class Process
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("version")]
        public string Version { get; set; }
        [XmlAttribute("bpversion")]
        public string BpVersion { get; set; }
        [XmlAttribute("narrative")]
        public string Narrative { get; set; }
        [XmlAttribute("byrefcollection")]
        public string ByRefCollection { get; set; }
        [XmlAttribute("preferredid")]
        public string PreferredId { get; set; }

        [XmlElement("view")]
        public View View { get; set; }

        [XmlElement("logging")]
        public Logging Logging { get; set; }
        [XmlArray("preconditions")]
        public List<Condition> Preconditions { get; set; }
        [XmlElement("endpoint")]
        public Endpoint Endpoint { get; set; }

        [XmlElement("subsheet")]
        public List<Subsheet> Subsheets { get; set; } 
        [XmlElement("stage")]
        public List<Stage> Stages { get; set; }

        [XmlIgnore]
        public bool PreconditionsSpecified
        {
            get { return (this.Preconditions != null && this.Preconditions.Count > 0); }
        }
    }
}
