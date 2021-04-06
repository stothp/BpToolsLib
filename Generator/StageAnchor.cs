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
    public class StageAnchor: Stage
    {
        readonly BpTools.StageAnchor stage;

        public StageAnchor(BpTools.StageAnchor stage, string subsheetId) : base(stage, subsheetId)
        {
            this.stage = stage;
        }

        public override XmlClasses.Stage GetBpStage()
        {
            XmlClasses.Stage bpStage = base.GetBpStage();

            if (stage.NextStage != null) 
            {
                bpStage.OnSuccess = stage.NextStage.Id;
            }

            return bpStage;
        }
    }
}
