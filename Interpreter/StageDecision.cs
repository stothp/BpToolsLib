using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.Interpreter
{
    public class StageDecision : Stage, ITraversable
    {
        public BpTools.StageDecision BpStageDecision 
        { 
            get 
            { 
                return (BpTools.StageDecision)base.BpStage; 
            } 
        }

        public StageDecision(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpTools.StageDecision();
            Initialize();
        }

        public override BpTools.Stage GetStage()
        {
            BpStageDecision.Expression = XmlStage.Decision.Expression;
            if (XmlStage.OnTrue != null)
            {
                BpStageDecision.OnTrue = new BpTools.StageReference(XmlStage.OnTrue);
            }
            if (XmlStage.OnTrue != null)
            {
                BpStageDecision.OnFalse = new BpTools.StageReference(XmlStage.OnFalse);
            }
            return BpStage;
        }

        public void SetNextStages(BpTools.StageSet set)
        {
            if (BpStageDecision.OnTrue != null)
            {
                BpStageDecision.OnTrue = set.Where(s => s.Id == BpStageDecision.OnTrue.Id).First();
            }
            if (BpStageDecision.OnFalse != null)
            {
                BpStageDecision.OnFalse = set.Where(s => s.Id == BpStageDecision.OnFalse.Id).First();
            }
        }

    }
}
