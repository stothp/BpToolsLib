using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.Interpreter
{
    public class StageChoiceEnd : Stage, ITraversable
    {
        public BpTools.StageChoiceEnd BpStageChoiceEnd
        { 
            get 
            { 
                return (BpTools.StageChoiceEnd)base.BpStage; 
            } 
        }

        public StageChoiceEnd(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpTools.StageChoiceEnd();
            Initialize();
        }

        public override BpTools.Stage GetStage()
        {
            BpStageChoiceEnd.GroupId = XmlStage.GroupId;
            if (XmlStage.OnSuccess != null)
            {
                BpStageChoiceEnd.NextStage = new BpTools.StageReference(XmlStage.OnSuccess);
            }

            return BpStage;
        }

        public void SetNextStages(BpTools.StageSet set)
        {
            if (BpStageChoiceEnd.NextStage != null)
            {
                BpStageChoiceEnd.NextStage = set.Where(s => s.Id == BpStageChoiceEnd.NextStage.Id).First();
            }
        }


    }
}
