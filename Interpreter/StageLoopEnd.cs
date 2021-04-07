using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.Interpreter
{
    public class StageLoopEnd : Stage, ITraversable
    {
        public BpTools.StageLoopEnd BpStageLoopEnd
        { 
            get 
            { 
                return (BpTools.StageLoopEnd)base.BpStage; 
            } 
        }

        public StageLoopEnd(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpTools.StageLoopEnd();
            Initialize();
        }

        public override BpTools.Stage GetStage()
        {
            BpStageLoopEnd.GroupId = XmlStage.GroupId;
            if (XmlStage.OnSuccess != null)
            {
                BpStageLoopEnd.NextStage = new BpTools.StageReference(XmlStage.OnSuccess);
            }

            return BpStage;
        }

        public void SetNextStages(BpTools.StageSet set)
        {
            if (BpStageLoopEnd.NextStage != null)
            {
                BpStageLoopEnd.NextStage = set.Where(s => s.Id == BpStageLoopEnd.NextStage.Id).First();
            }
        }


    }
}
