using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BpToolsLib.XmlClasses
{
    [XmlType(TypeName = "logging")]
    public class Logging
    {
        [XmlAttribute("abort-on-error")]
        public bool AbortOnError;

        [XmlAttribute("attempts")]
        public int Attempts;

        [XmlAttribute("retry-period")]
        public int RetryPeriod;
    }
}
