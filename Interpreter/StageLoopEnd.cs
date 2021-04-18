using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib.Interpreter
{
    public class StageLoopEnd : Stage, ITraversable
    {
        public BpToolsLib.StageLoopEnd BpStageLoopEnd
        { 
            get 
            { 
                return (BpToolsLib.StageLoopEnd)base.BpStage; 
            } 
        }

        public StageLoopEnd(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpToolsLib.StageLoopEnd();
            Initialize();
        }

        public override BpToolsLib.Stage GetStage()
        {
            BpStageLoopEnd.GroupId = XmlStage.GroupId;
            if (XmlStage.OnSuccess != null)
            {
                BpStageLoopEnd.NextStage = new BpToolsLib.StageReference(XmlStage.OnSuccess);
            }

            return BpStage;
        }

        public void SetNextStages(BpToolsLib.StageSet set)
        {
            if (BpStageLoopEnd.NextStage != null)
            {
                BpStageLoopEnd.NextStage = set.Where(s => s.Id == BpStageLoopEnd.NextStage.Id).First();
            }
        }


    }
}
