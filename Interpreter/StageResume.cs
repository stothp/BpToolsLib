using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.Interpreter
{
    public class StageResume : Stage, ITraversable
    {
        public BpTools.StageResume BpStageResume 
        { 
            get 
            { 
                return (BpTools.StageResume)base.BpStage; 
            } 
        }

        public StageResume(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpTools.StageResume();
            Initialize();
        }

        public override BpTools.Stage GetStage()
        {
            if (XmlStage.OnSuccess != null)
            {
                BpStageResume.NextStage = new BpTools.StageReference(XmlStage.OnSuccess);
            }
            return BpStage;
        }

        public void SetNextStages(BpTools.StageSet set)
        {
            if (BpStageResume.NextStage != null)
            {
                BpStageResume.NextStage = set.Where(s => s.Id == BpStageResume.NextStage.Id).First();
            }
        }

    }
}
