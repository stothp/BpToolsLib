using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.Interpreter
{
    public class StageMultipleCalculation : Stage, ITraversable
    {
        public BpTools.StageMultipleCalculation BpStageMultipleCalculation
        { 
            get 
            { 
                return (BpTools.StageMultipleCalculation)base.BpStage; 
            } 
        }

        public StageMultipleCalculation(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpTools.StageMultipleCalculation();
            Initialize();
        }

        public override BpTools.Stage GetStage()
        {
            foreach (XmlClasses.Calculation calc in XmlStage.Steps)
            {
                BpStageMultipleCalculation.Calculations.Add(new BpTools.Calculation(calc.Expression, calc.Stage));
            }

            if (XmlStage.OnSuccess != null)
            {
                BpStageMultipleCalculation.NextStage = new BpTools.StageReference(XmlStage.OnSuccess);
            }
            return BpStage;
        }

        public void SetNextStages(BpTools.StageSet set)
        {
            if (BpStageMultipleCalculation.NextStage.Id != null)
            {
                BpStageMultipleCalculation.NextStage = set.Where(s => s.Id == BpStageMultipleCalculation.NextStage.Id).First();
            }
        }

    }
}
