using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib.Interpreter
{
    public class StageResume : Stage, ITraversable
    {
        public BpToolsLib.StageResume BpStageResume 
        { 
            get 
            { 
                return (BpToolsLib.StageResume)base.BpStage; 
            } 
        }

        public StageResume(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpToolsLib.StageResume();
            Initialize();
        }

        public override BpToolsLib.Stage GetStage()
        {
            if (XmlStage.OnSuccess != null)
            {
                BpStageResume.NextStage = new BpToolsLib.StageReference(XmlStage.OnSuccess);
            }
            return BpStage;
        }

        public void SetNextStages(BpToolsLib.StageSet set)
        {
            if (BpStageResume.NextStage != null)
            {
                BpStageResume.NextStage = set.Where(s => s.Id == BpStageResume.NextStage.Id).First();
            }
        }

    }
}
