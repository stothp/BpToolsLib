using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using BpTools;


namespace BpTools.ToBp
{
    public static class End
    {
        public static BpClasses.Stage getXmlObj (BpTools.End end, string subsheetId)
        {
            BpClasses.Stage xmlObj = Stage.getXmlObj(end, "End", subsheetId);
            
            if (end.OutputParameters.Count > 0)
            {
                xmlObj.Outputs = new List<BpClasses.Output>();
                foreach (BpTools.Parameter param in end.OutputParameters)
                {
                    BpClasses.Output output = new BpClasses.Output();
                    output.Name = param.Name;
                    output.Type = DataTypeConverter.GetText(param.Type);
                    output.Narrative = param.Description;
                    output.Stage = param.StageName;

                    xmlObj.Outputs.Add(output);
                }
            }

            return xmlObj;
        }
    }
}
