using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.Interpreter
{
    public class StageAnchor : Stage, ITraversable
    {
        public BpTools.StageAnchor BpStageAnchor        
        { 
            get 
            { 
                return (BpTools.StageAnchor)base.BpStage; 
            } 
        }

        public StageAnchor(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpTools.StageAnchor();
            Initialize();
        }

        public override BpTools.Stage GetStage()
        {
            if (XmlStage.OnSuccess != null)
            {
                BpStageAnchor.NextStage = new BpTools.StageReference(XmlStage.OnSuccess);
            }
            return BpStage;
        }

        public void SetNextStages(BpTools.StageSet set)
        {
            if (BpStageAnchor.NextStage != null)
            {
                BpStageAnchor.NextStage = set.Where(s => s.Id == BpStageAnchor.NextStage.Id).First();
            }
        }

    }
}
