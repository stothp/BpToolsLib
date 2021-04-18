using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using BpToolsLib;
using BpToolsLib.Interpreter;

namespace BpToolsLib.Generator
{
    public class StageLoop : Stage
    {
        readonly BpToolsLib.StageLoop stage;

        public StageLoop(BpToolsLib.StageLoop stage, string subsheetId) : base(stage, subsheetId)
        {
            this.stage = stage;
        }

        public override XmlClasses.Stage GetBpStage()
        {
            XmlClasses.Stage bpStage = base.GetBpStage();

            bpStage.LoopType = stage.LoopType;
            bpStage.LoopData = stage.LoopCollectionName;
            bpStage.GroupId = stage.GroupId;

            if (stage.NextStage != null)
            {
                bpStage.OnSuccess = stage.NextStage.Id;
            }

            return bpStage;
        }
    }
}
