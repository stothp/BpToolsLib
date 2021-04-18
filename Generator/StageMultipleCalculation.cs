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
    public class StageMultipleCalculation : Stage
    {
        readonly BpToolsLib.StageMultipleCalculation stage;

        public StageMultipleCalculation(BpToolsLib.StageMultipleCalculation stage, string subsheetId) : base(stage, subsheetId)
        {
            this.stage = stage;
        }

        public override XmlClasses.Stage GetBpStage()
        {
            XmlClasses.Stage bpStage = base.GetBpStage();

            bpStage.Steps = new List<XmlClasses.Calculation>();
            foreach (BpToolsLib.Calculation calc in stage.Calculations)
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
