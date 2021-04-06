using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using BpTools;
using BpTools.XmlClasses;
using BpTools.Interpreter;

namespace BpTools.Generator
{
    public class StageAlert : Stage
    {
        readonly BpTools.StageAlert stage;

        public StageAlert(BpTools.StageAlert stage, string subsheetId) : base(stage, subsheetId)
        {
            this.stage = stage;
        }

        public override XmlClasses.Stage GetBpStage()
        {
            XmlClasses.Stage bpStage = base.GetBpStage();

            bpStage.Alert = new XmlClasses.Alert();
            bpStage.Alert.Expression = stage.Expression;

            if (stage.NextStage != null) 
            {
                bpStage.OnSuccess = stage.NextStage.Id;
            }

            return bpStage;
        }
    }
}
