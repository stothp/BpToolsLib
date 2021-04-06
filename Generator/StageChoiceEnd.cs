using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using BpTools;
using BpTools.XmlClasses;
using BpTools.Interpreter;

namespace BpTools.Generator
{
    public class StageChoiceEnd : Stage
    {
        readonly BpTools.StageChoiceEnd stage;

        public StageChoiceEnd(BpTools.StageChoiceEnd stage, string subsheetId) : base(stage, subsheetId)
        {
            this.stage = stage;
        }

        public override XmlClasses.Stage GetBpStage()
        {
            XmlClasses.Stage bpStage = base.GetBpStage();

            bpStage.GroupId = stage.GroupId;
            bpStage.OnSuccess = stage.NextStage.Id;

            return bpStage;
        }
    }
}
