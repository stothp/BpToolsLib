using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib.Interpreter
{
    public class StageLoop : Stage, ITraversable
    {
        public BpToolsLib.StageLoop BpStageLoop
        { 
            get 
            { 
                return (BpToolsLib.StageLoop)base.BpStage; 
            } 
        }

        public StageLoop(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpToolsLib.StageLoop();
            Initialize();
        }

        public override BpToolsLib.Stage GetStage()
        {
            BpStageLoop.GroupId = XmlStage.GroupId;
            BpStageLoop.LoopEnd.GroupId = XmlStage.GroupId;
            BpStageLoop.LoopType = XmlStage.LoopType;
            BpStageLoop.LoopCollectionName = XmlStage.LoopData;
            if (XmlStage.OnSuccess != null)
            {
                BpStageLoop.NextStage = new BpToolsLib.StageReference(XmlStage.OnSuccess);
            }
            return BpStage;
        }

        public void SetNextStages(BpToolsLib.StageSet set)
        {
            if (BpStageLoop.NextStage != null)
            {
                BpStageLoop.NextStage = set.Where(s => s.Id == BpStageLoop.NextStage.Id).First();
            }
            if (BpStageLoop.GroupId != null)
            {
                BpStageLoop.LoopEnd = (BpToolsLib.StageLoopEnd)set.Where(s => s is BpToolsLib.StageLoopEnd && ((BpToolsLib.StageLoopEnd)s).GroupId == BpStageLoop.GroupId).First();
            }
        }

    }
}
