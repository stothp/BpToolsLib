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
    public class StageMultipleCalculation : Stage
    {
        readonly BpTools.StageMultipleCalculation stage;

        public StageMultipleCalculation(BpTools.StageMultipleCalculation stage, string subsheetId) : base(stage, subsheetId)
        {
            this.stage = stage;
        }

        public override XmlClasses.Stage GetBpStage()
        {
            XmlClasses.Stage bpStage = base.GetBpStage();

            bpStage.Steps = new List<XmlClasses.Calculation>();
            foreach (BpTools.Calculation calc in stage.Calculations)
            {
                bpStage.Steps.Add(
                    new XmlClasses.Calculation()
                    {
                        Expression = calc.Expression,
                        Stage = calc.DataName
                    }
                );
            }
         
            if (stage.NextStage != null)
            {
                bpStage.OnSuccess = stage.NextStage.Id;
            }

            return bpStage;
        }
    }
}
