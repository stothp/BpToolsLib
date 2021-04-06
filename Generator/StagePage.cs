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
    public class StagePage : Stage
    {
        readonly BpTools.StagePage stage;

        public StagePage(BpTools.StagePage stage, string subsheetId) : base(stage, subsheetId)
        {
            this.stage = stage;
        }

        public override XmlClasses.Stage GetBpStage()
        {
            XmlClasses.Stage bpStage = base.GetBpStage();

            bpStage.Inputs = new List<XmlClasses.Input>();
            bpStage.Outputs = new List<XmlClasses.Output>();

            foreach (BpTools.InputParameter param in stage.InputParameters)
            {
                bpStage.Inputs.Add(new InputParameter(param).GetInput());
            }

            foreach (BpTools.OutputParameter param in stage.OutputParameters)
            {
                bpStage.Outputs.Add(new OutputParameter(param).GetOutput());
            }

            bpStage.ProcessId = stage.Page.Id;

            if (stage.NextStage != null) 
            {
                bpStage.OnSuccess = stage.NextStage.Id;
            }

            return bpStage;
        }
    }
}
