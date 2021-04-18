using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib.Interpreter
{
    public class StageCalculation : Stage, ITraversable
    {
        public BpToolsLib.StageCalculation BpStageCalculation
        { 
            get 
            { 
                return (BpToolsLib.StageCalculation)base.BpStage; 
            } 
        }

        public StageCalculation(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpToolsLib.StageCalculation();
            Initialize();
        }

        public override BpToolsLib.Stage GetStage()
        {
            BpStageCalculation.Expression = XmlStage.Calculation.Expression;
            BpStageCalculation.DataName = XmlStage.Calculation.Stage;
            if (XmlStage.OnSuccess != null)
            {
                BpStageCalculation.NextStage = new BpToolsLib.StageReference(XmlStage.OnSuccess);
            }
            return BpStage;
        }

        public void SetNextStages(BpToolsLib.StageSet set)
        {
            if (BpStageCalculation.NextStage != null)
            {
                BpStageCalculation.NextStage = set.Where(s => s.Id == BpStageCalculation.NextStage.Id).First();
            }
        }

    }
}
