using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib.Interpreter
{
    public class StageAnchor : Stage, ITraversable
    {
        public BpToolsLib.StageAnchor BpStageAnchor        
        { 
            get 
            { 
                return (BpToolsLib.StageAnchor)base.BpStage; 
            } 
        }

        public StageAnchor(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpToolsLib.StageAnchor();
            Initialize();
        }

        public override BpToolsLib.Stage GetStage()
        {
            if (XmlStage.OnSuccess != null)
            {
                BpStageAnchor.NextStage = new BpToolsLib.StageReference(XmlStage.OnSuccess);
            }
            return BpStage;
        }

        public void SetNextStages(BpToolsLib.StageSet set)
        {
            if (BpStageAnchor.NextStage != null)
            {
                BpStageAnchor.NextStage = set.Where(s => s.Id == BpStageAnchor.NextStage.Id).First();
            }
        }

    }
}
