using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;


namespace BpTools.ToBp
{
    public static class Data
    {
        public static BpClasses.Stage getXmlObj (BpTools.Data data, string subsheetId)
        {
            BpClasses.Stage xmlObj = Stage.getXmlObj(data, "Data", subsheetId);
            
            return xmlObj;
        }
    }
}
