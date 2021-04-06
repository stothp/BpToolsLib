using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.Interpreter
{
    public class StageRecover : Stage, ITraversable
    {
        public BpTools.StageRecover BpStageRecover 
        { 
            get 
            { 
                return (BpTools.StageRecover)base.BpStage; 
            } 
        }

        public StageRecover(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpTools.StageRecover();
            Initialize();
        }

        public override BpTools.Stage GetStage()
        {
            if (XmlStage.OnSuccess != null)
            {
                BpStageRecover.NextStage = new BpTools.StageReference(XmlStage.OnSuccess);
            }
            return BpStage;
        }

        public void SetNextStages(BpTools.StageSet set)
        {
            if (BpStageRecover.NextStage != null)
            {
                BpStageRecover.NextStage = set.Where(s => s.Id == BpStageRecover.NextStage.Id).First();
            }
        }

    }
}
