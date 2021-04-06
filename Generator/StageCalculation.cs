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
    public class StageCalculation: Stage
    {
        readonly BpTools.StageCalculation stage;

        public StageCalculation(BpTools.StageCalculation stage, string subsheetId) : base(stage, subsheetId)
        {
            this.stage = stage;
        }

        public override XmlClasses.Stage GetBpStage()
        {
            XmlClasses.Stage bpStage = base.GetBpStage();

            bpStage.Calculation = new XmlClasses.Calculation()
            {
                Expression = stage.Expression,
                Stage = stage.DataName
            };
            

            if (stage.NextStage != null)
            {
                bpStage.OnSuccess = stage.NextStage.Id;
            }

            return bpStage;
        }
    }
}
