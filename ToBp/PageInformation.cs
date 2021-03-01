using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using BpTools;


namespace BpTools.ToBp
{
    public static class PageInformation
    {
        public static BpClasses.Stage getXmlObj (BpTools.PageInformation pageInformation, string subsheetId)
        {
            return Stage.getXmlObj(pageInformation, "SubSheetInfo", subsheetId);
        }
    }
}
