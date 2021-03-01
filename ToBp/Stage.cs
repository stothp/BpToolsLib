using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using BpTools;


namespace BpTools.ToBp
{
    public static class Stage
    {
        public static BpClasses.Stage getXmlObj (BpTools.Stage stage, string type, string subsheetId)
        {
            BpClasses.Stage xmlObj = new BpClasses.Stage();
            xmlObj.StageId = stage.Id;
            xmlObj.Name = stage.Name;
            xmlObj.Type = type;
            if (subsheetId != null)
            {
                xmlObj.SubsheetId = subsheetId;
            }
            xmlObj.Narrative = stage.Description;
            xmlObj.DisplayX = stage.X;
            xmlObj.DisplayY = stage.Y;
            xmlObj.DisplayWidth = stage.Width;
            xmlObj.DisplayHeight = stage.Height;
            
            if (stage.Font != null)
            {
                xmlObj.Font = Font.GetXmlObj(stage.Font);
            }

            if (stage is BpTools.ILeavable)
            {
                xmlObj.OnSuccess = ((BpTools.ILeavable)stage).NextStage.Id;
            }

            return xmlObj;
        }
    }
}
