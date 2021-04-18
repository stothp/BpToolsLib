using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib.Interpreter
{
    public class StageAlert : Stage, ITraversable
    {
        public BpToolsLib.StageAlert BpStageAlert
        { 
            get 
            { 
                return (BpToolsLib.StageAlert)base.BpStage; 
            } 
        }

        public StageAlert(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpToolsLib.StageAlert();
            Initialize();
        }

        public override BpToolsLib.Stage GetStage()
        {
            BpStageAlert.Expression = XmlStage.Alert.Expression;
            if (XmlStage.OnSuccess != null)
            {
                BpStageAlert.NextStage = new BpToolsLib.StageReference(XmlStage.OnSuccess);
            }
            return BpStage;
        }

        public void SetNextStages(BpToolsLib.StageSet set)
        {
            if (BpStageAlert.NextStage != null)
            {
                BpStageAlert.NextStage = set.Where(s => s.Id == BpStageAlert.NextStage.Id).First();
            }
        }

    }
}
