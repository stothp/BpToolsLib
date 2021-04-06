using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.Interpreter
{
    public class StagePageInfo : Stage
    {
        public BpTools.StagePageInfo BpStagePageInfo 
        { 
            get 
            { 
                return (BpTools.StagePageInfo)base.BpStage; 
            } 
        }

        public StagePageInfo(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpTools.StagePageInfo();
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
