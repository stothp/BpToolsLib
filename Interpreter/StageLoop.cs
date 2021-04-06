using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.Interpreter
{
    public class StageLoop : Stage, ITraversable
    {
        public BpTools.StageLoop BpStageLoop
        { 
            get 
            { 
                return (BpTools.StageLoop)base.BpStage; 
            } 
        }

        public StageLoop(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpTools.StageLoop();
            Initialize();
        }

        public override BpTools.Stage GetStage()
        {
            BpStageLoop.GroupId = XmlStage.GroupId;
            BpStageLoop.LoopEnd.GroupId = XmlStage.GroupId;
            BpStageLoop.LoopType = XmlStage.LoopType;
            BpStageLoop.LoopCollectionName = XmlStage.LoopData;
            if (XmlStage.OnSuccess != null)
            {
                BpStageLoop.NextStage = new BpTools.StageReference(XmlStage.OnSuccess);
            }
            return BpStage;
        }

        public void SetNextStages(BpTools.StageSet set)
        {
            if (BpStageLoop.NextStage != null)
            {
                BpStageLoop.NextStage = set.Where(s => s.Id == BpStageLoop.NextStage.Id).First();
            }
            if (BpStageLoop.GroupId != null)
            {
                BpStageLoop.LoopEnd = (BpTools.StageLoopEnd)set.Where(s => s is BpTools.StageLoopEnd && ((BpTools.StageLoopEnd)s).GroupId == BpStageLoop.GroupId).First();
            }
        }

    }
}
