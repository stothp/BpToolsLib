using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using BpTools;


namespace BpTools.ToBp
{
    public static class StageFactory
    {
        public static BpClasses.Stage getXmlObj(BpTools.Stage stage, string subsheetId)
        {
            if (stage is BpTools.Data)
            {
                return Data.getXmlObj((BpTools.Data)stage, subsheetId);
            }
            else if (stage is BpTools.End)
            {
                return End.getXmlObj((BpTools.End)stage, subsheetId);
            }
            else if (stage is BpTools.PageInformation)
            {
                return PageInformation.getXmlObj((BpTools.PageInformation)stage, subsheetId);
            }
            else if (stage is BpTools.Start)
            {
                return Start.getXmlObj((BpTools.Start)stage, subsheetId);
            }
            else
            {
                throw new Exception("Unknown Stage type: " + stage.GetType());
            }
        }
    }
}
