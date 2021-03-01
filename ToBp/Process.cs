using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using BpTools;


namespace BpTools.ToBp
{
    public static class Process
    {
        public static BpClasses.Process getXmlProcess (BpTools.Process process)
        {
            BpClasses.Process xmlObj = new BpClasses.Process();

            xmlObj.Name = process.Name;
            xmlObj.Version = process.Version;
            xmlObj.BpVersion = process.BpVersion;
            xmlObj.Narrative = process.Description;
            xmlObj.ByRefCollection = process.ByRefCollection;
            xmlObj.PreferredId = process.Id;

            return xmlObj;
        }
    }
}
