using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib.Interpreter
{
    public class StageDecision : Stage, ITraversable
    {
        public BpToolsLib.StageDecision BpStageDecision 
        { 
            get 
            { 
                return (BpToolsLib.StageDecision)base.BpStage; 
            } 
        }

        public StageDecision(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpToolsLib.StageDecision();
            Initialize();
        }

        public override BpToolsLib.Stage GetStage()
        {
            BpStageDecision.Expression = XmlStage.Decision.Expression;
            if (XmlStage.OnTrue != null)
            {
                BpStageDecision.OnTrue = new BpToolsLib.StageReference(XmlStage.OnTrue);
            }
            if (XmlStage.OnTrue != null)
            {
                BpStageDecision.OnFalse = new BpToolsLib.StageReference(XmlStage.OnFalse);
            }
            return BpStage;
        }

        public void SetNextStages(BpToolsLib.StageSet set)
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
