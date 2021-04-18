using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib.Interpreter
{
    public class StageMultipleCalculation : Stage, ITraversable
    {
        public BpToolsLib.StageMultipleCalculation BpStageMultipleCalculation
        { 
            get 
            { 
                return (BpToolsLib.StageMultipleCalculation)base.BpStage; 
            } 
        }

        public StageMultipleCalculation(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpToolsLib.StageMultipleCalculation();
            Initialize();
        }

        public override BpToolsLib.Stage GetStage()
        {
            foreach (XmlClasses.Calculation calc in XmlStage.Steps)
            {
                BpStageMultipleCalculation.Calculations.Add(new BpToolsLib.Calculation(calc.Expression, calc.Stage));
            }

            if (XmlStage.OnSuccess != null)
            {
                BpStageMultipleCalculation.NextStage = new BpToolsLib.StageReference(XmlStage.OnSuccess);
            }
            return BpStage;
        }

        public void SetNextStages(BpToolsLib.StageSet set)
        {
            if (BpStageMultipleCalculation.NextStage != null)
            {
                BpStageMultipleCalculation.NextStage = set.Where(s => s.Id == BpStageMultipleCalculation.NextStage.Id).First();
            }
        }

    }
}
