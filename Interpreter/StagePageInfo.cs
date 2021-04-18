using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib.Interpreter
{
    public class StagePageInfo : Stage
    {
        public BpToolsLib.StagePageInfo BpStagePageInfo 
        { 
            get 
            { 
                return (BpToolsLib.StagePageInfo)base.BpStage; 
            } 
        }

        public StagePageInfo(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpToolsLib.StagePageInfo();
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
