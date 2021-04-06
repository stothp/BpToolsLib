using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using BpTools;


namespace BpTools.Generator
{
    public abstract class Stage
    {

        readonly BpTools.Stage stage;
        readonly string subsheetId;

        public Stage (BpTools.Stage stage, string subsheetId)
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
            bpStage.Narrative = stage.Description;
            bpStage.DisplayX = stage.X;
            bpStage.DisplayY = stage.Y;
            bpStage.DisplayWidth = stage.Width;
            bpStage.DisplayHeight = stage.Height;
            
            if (stage.Font != null)
            {
                bpStage.Font = new Font(stage.Font).GetFont();
            }

            return bpStage;
        }
    }
}
