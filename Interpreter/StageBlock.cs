using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib.Interpreter
{
    public class StageBlock : Stage
    {
        public BpToolsLib.StageBlock BpStageBlock 
        { 
            get 
            { 
                return (BpToolsLib.StageBlock)base.BpStage; 
            } 
        }

        public StageBlock(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpToolsLib.StageBlock();
            Initialize();
        }

        public override BpToolsLib.Stage GetStage()
        {
            return BpStage;
        }

        public void SetNextStages(BpToolsLib.StageSet set)
        {
        }

    }
}
