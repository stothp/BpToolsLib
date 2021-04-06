using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.Interpreter
{
    public class StageNote : Stage, ITraversable
    {
        public BpTools.StageNote BpStageNote 
        { 
            get 
            { 
                return (BpTools.StageNote)base.BpStage; 
            } 
        }

        public StageNote(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpTools.StageNote();
            Initialize();
        }

        public override BpTools.Stage GetStage()
        {
            if (XmlStage.OnSuccess != null)
            {
                BpStageNote.NextStage = new BpTools.StageReference(XmlStage.OnSuccess);
            }
            return BpStage;
        }

        public void SetNextStages(BpTools.StageSet set)
        {
            if (BpStageNote.NextStage != null)
            {
                BpStageNote.NextStage = set.Where(s => s.Id == BpStageNote.NextStage.Id).First();
            }
        }

    }
}
