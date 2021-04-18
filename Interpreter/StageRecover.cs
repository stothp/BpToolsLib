using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib.Interpreter
{
    public class StageRecover : Stage, ITraversable
    {
        public BpToolsLib.StageRecover BpStageRecover 
        { 
            get 
            { 
                return (BpToolsLib.StageRecover)base.BpStage; 
            } 
        }

        public StageRecover(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpToolsLib.StageRecover();
            Initialize();
        }

        public override BpToolsLib.Stage GetStage()
        {
            if (XmlStage.OnSuccess != null)
            {
                BpStageRecover.NextStage = new BpToolsLib.StageReference(XmlStage.OnSuccess);
            }
            return BpStage;
        }

        public void SetNextStages(BpToolsLib.StageSet set)
        {
            if (BpStageRecover.NextStage != null)
            {
                BpStageRecover.NextStage = set.Where(s => s.Id == BpStageRecover.NextStage.Id).First();
            }
        }

    }
}
