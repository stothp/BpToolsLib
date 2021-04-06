using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.Interpreter
{
    public class StageBlock : Stage
    {
        public BpTools.StageBlock BpStageBlock 
        { 
            get 
            { 
                return (BpTools.StageBlock)base.BpStage; 
            } 
        }

        public StageBlock(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpTools.StageBlock();
            Initialize();
        }

        public override BpTools.Stage GetStage()
        {
            return BpStage;
        }

        public void SetNextStages(BpTools.StageSet set)
        {
        }

    }
}
