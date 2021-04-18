using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib.Interpreter
{
    public class StageChoiceEnd : Stage, ITraversable
    {
        public BpToolsLib.StageChoiceEnd BpStageChoiceEnd
        { 
            get 
            { 
                return (BpToolsLib.StageChoiceEnd)base.BpStage; 
            } 
        }

        public StageChoiceEnd(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpToolsLib.StageChoiceEnd();
            Initialize();
        }

        public override BpToolsLib.Stage GetStage()
        {
            BpStageChoiceEnd.GroupId = XmlStage.GroupId;
            if (XmlStage.OnSuccess != null)
            {
                BpStageChoiceEnd.NextStage = new BpToolsLib.StageReference(XmlStage.OnSuccess);
            }

            return BpStage;
        }

        public void SetNextStages(BpToolsLib.StageSet set)
        {
            if (BpStageChoiceEnd.NextStage != null)
            {
                BpStageChoiceEnd.NextStage = set.Where(s => s.Id == BpStageChoiceEnd.NextStage.Id).First();
            }
        }


    }
}
