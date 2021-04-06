using System;
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
    public class StageDecision: Stage
    {
        readonly BpTools.StageDecision stage;

        public StageDecision(BpTools.StageDecision stage, string subsheetId) : base(stage, subsheetId)
        {
            this.stage = stage;
        }

        public override XmlClasses.Stage GetBpStage()
        {
            XmlClasses.Stage bpStage = base.GetBpStage();

            bpStage.Decision = new XmlClasses.Decision()
            {
                Expression = stage.Expression
            };

            if (stage.OnFalse != null)
            {
                bpStage.OnFalse = stage.OnFalse.Id;
            }

            if (stage.OnTrue != null)
            {
                bpStage.OnTrue = stage.OnTrue.Id;
            }

            return bpStage;
        }
    }
}
