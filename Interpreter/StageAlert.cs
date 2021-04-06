using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.Interpreter
{
    public class StageAlert : Stage, ITraversable
    {
        public BpTools.StageAlert BpStageAlert
        { 
            get 
            { 
                return (BpTools.StageAlert)base.BpStage; 
            } 
        }

        public StageAlert(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpTools.StageAlert();
            Initialize();
        }

        public override BpTools.Stage GetStage()
        {
            BpStageAlert.Expression = XmlStage.Alert.Expression;
            if (XmlStage.OnSuccess != null)
            {
                BpStageAlert.NextStage = new BpTools.StageReference(XmlStage.OnSuccess);
            }
            return BpStage;
        }

        public void SetNextStages(BpTools.StageSet set)
        {
            if (BpStageAlert.NextStage != null)
            {
                BpStageAlert.NextStage = set.Where(s => s.Id == BpStageAlert.NextStage.Id).First();
            }
        }

    }
}
