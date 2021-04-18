using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using BpToolsLib;


namespace BpToolsLib.Generator
{
    public abstract class Stage
    {

        readonly BpToolsLib.Stage stage;
        readonly string subsheetId;

        public Stage (BpToolsLib.Stage stage, string subsheetId)
        {
            this.stage = stage;
            this.subsheetId = subsheetId;
        }

        public virtual XmlClasses.Stage GetBpStage ()
        {
            XmlClasses.Stage bpStage = new XmlClasses.Stage();
            bpStage.StageId = stage.Id;
            bpStage.Name = stage.Name;
            bpStage.Type = StageTypeConverter.GetText(stage.Type);
            bpStage.SubsheetId = this.subsheetId;
            if (!stage.Description.Equals(""))
            {
                bpStage.Narrative = stage.Description;
            }
            //bpStage.DisplayX = stage.X;
            //bpStage.DisplayY = stage.Y;
            //bpStage.DisplayWidth = stage.Width;
            //bpStage.DisplayHeight = stage.Height;
            bpStage.Display = new XmlClasses.Display();
            bpStage.Display.X = stage.X;
            bpStage.Display.Y = stage.Y;
            bpStage.Display.W = stage.Width;
            bpStage.Display.H = stage.Height;

            if (stage.Font != null)
            {
                bpStage.Font = new Font(stage.Font).GetFont();
            }

            return bpStage;
        }
    }
}
