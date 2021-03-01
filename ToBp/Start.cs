using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using BpTools;


namespace BpTools.ToBp
{
    public static class Start
    {
        public static BpClasses.Stage getXmlObj (BpTools.Start start, string subsheetId)
        {
            BpClasses.Stage xmlObj = Stage.getXmlObj(start, "Start", subsheetId);
            
            if (start.InputParameters.Count > 0)
            {
                xmlObj.Inputs = new List<BpClasses.Input>();
                foreach (BpTools.Parameter param in start.InputParameters)
                {
                    BpClasses.Input input = new BpClasses.Input();
                    input.Name = param.Name;
                    input.Type = DataTypeConverter.GetText(param.Type);
                    input.Narrative = param.Description;
                    input.Stage = param.StageName;

                    xmlObj.Inputs.Add(input);
                }
            }

            return xmlObj;
        }
    }
}
