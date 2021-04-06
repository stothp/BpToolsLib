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
    public class StageAction : Stage
    {
        readonly BpTools.StageAction stage;

        public StageAction(BpTools.StageAction stage, string subsheetId) : base(stage, subsheetId)
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

            bpStage.Resource = new XmlClasses.Resource();
            bpStage.Resource.Object = stage.ActionReference.Vbo;
            bpStage.Resource.Action = stage.ActionReference.Page;

            if (stage.NextStage != null) 
            {
                bpStage.OnSuccess = stage.NextStage.Id;
            }

            return bpStage;
        }
    }
}
