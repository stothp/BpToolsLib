using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BpTools
{
    class XmlFragmentWriter : XmlTextWriter
    {
        public XmlFragmentWriter(TextWriter writer) : base (writer)
        {

        }

        override public void WriteStartDocument()
        {

        }

        override public void WriteStartDocument(bool standalone)
        {

        }
    }
}
