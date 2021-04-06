using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using BpTools;
using BpTools.Interpreter;

namespace BpTools.Generator
{
    public class StageStart : Stage
    {
        readonly BpTools.StageStart stage;

        public StageStart(BpTools.StageStart stage, string subsheetId) : base(stage, subsheetId)
        {
            this.stage = stage;
        }

        public override XmlClasses.Stage GetBpStage()
        {
            XmlClasses.Stage bpStage = base.GetBpStage();

            bpStage.Inputs = new List<XmlClasses.Input>();

            foreach (BpTools.StartParameter param in stage.InputParameters)
            {
                bpStage.Inputs.Add(new StartParameter(param).GetInput());
            }

            if (stage.NextStage != null) 
            {
                bpStage.OnSuccess = stage.NextStage.Id;
            }

            return bpStage;
        }
    }
}
