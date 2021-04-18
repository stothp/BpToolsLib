﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BpToolsLib.XmlClasses
{
    [XmlType(TypeName = "decision")]
    public class Decision
    {
        [XmlAttribute("expression")]
        public string Expression { get; set; }
    }
}
