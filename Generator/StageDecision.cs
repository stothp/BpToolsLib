using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using BpToolsLib;
using BpToolsLib.XmlClasses;
using BpToolsLib.Interpreter;

namespace BpToolsLib.Generator
{
    public class StageDecision: Stage
    {
        readonly BpToolsLib.StageDecision stage;

        public StageDecision(BpToolsLib.StageDecision stage, string subsheetId) : base(stage, subsheetId)
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
