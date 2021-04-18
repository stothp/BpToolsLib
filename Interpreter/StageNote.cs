using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib.Interpreter
{
    public class StageNote : Stage, ITraversable
    {
        public BpToolsLib.StageNote BpStageNote 
        { 
            get 
            { 
                return (BpToolsLib.StageNote)base.BpStage; 
            } 
        }

        public StageNote(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpToolsLib.StageNote();
            Initialize();
        }

        public override BpToolsLib.Stage GetStage()
        {
            if (XmlStage.OnSuccess != null)
            {
                BpStageNote.NextStage = new BpToolsLib.StageReference(XmlStage.OnSuccess);
            }
            return BpStage;
        }

        public void SetNextStages(BpToolsLib.StageSet set)
        {
            if (BpStageNote.NextStage != null)
            {
                BpStageNote.NextStage = set.Where(s => s.Id == BpStageNote.NextStage.Id).First();
            }
        }

    }
}
