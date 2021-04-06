using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.Interpreter
{
    public class StageCalculation : Stage, ITraversable
    {
        public BpTools.StageCalculation BpStageCalculation
        { 
            get 
            { 
                return (BpTools.StageCalculation)base.BpStage; 
            } 
        }

        public StageCalculation(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpTools.StageCalculation();
            Initialize();
        }

        public override BpTools.Stage GetStage()
        {
            BpStageCalculation.Expression = XmlStage.Calculation.Expression;
            BpStageCalculation.DataName = XmlStage.Calculation.Stage;
            if (XmlStage.OnSuccess != null)
            {
                BpStageCalculation.NextStage = new BpTools.StageReference(XmlStage.OnSuccess);
            }
            return BpStage;
        }

        public void SetNextStages(BpTools.StageSet set)
        {
            if (BpStageCalculation.NextStage != null)
            {
                BpStageCalculation.NextStage = set.Where(s => s.Id == BpStageCalculation.NextStage.Id).First();
            }
        }

    }
}
