using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib.Interpreter
{
    public class StageProcess : Stage, ITraversable
    {
        public BpToolsLib.StageProcess BpStageProcess
        { 
            get 
            { 
                return (BpToolsLib.StageProcess)base.BpStage; 
            } 
        }

        public StageProcess(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpToolsLib.StageProcess();
            Initialize();
        }

        public override BpToolsLib.Stage GetStage()
        {
            foreach (XmlClasses.Input xmlInput in XmlStage.Inputs)
            {
                BpToolsLib.InputParameter parameter =
                    new BpToolsLib.InputParameter(
                        DataTypeConverter.GetDataTypeByName(xmlInput.Type)
                        , xmlInput.Name
                        , xmlInput.Narrative
                        , xmlInput.Expr);
                BpStageProcess.InputParameters.Add(parameter);
            }
            foreach (XmlClasses.Output xmlOutput in XmlStage.Outputs)
            {
                BpToolsLib.OutputParameter parameter =
                    new BpToolsLib.OutputParameter(
                        DataTypeConverter.GetDataTypeByName(xmlOutput.Type)
                        , xmlOutput.Name
                        , xmlOutput.Narrative
                        , xmlOutput.Stage);
                BpStageProcess.OutputParameters.Add(parameter);
            }
            BpStageProcess.Process = new BpToolsLib.Process()
            {
                Id = XmlStage.ProcessId
            };
            if (XmlStage.OnSuccess != null)
            {
                BpStageProcess.NextStage = new BpToolsLib.StageReference(XmlStage.OnSuccess);
            }
            return BpStage;
        }

        public void SetNextStages(BpToolsLib.StageSet set)
        {
            if (BpStageProcess.NextStage != null)
            {
                BpStageProcess.NextStage = set.Where(s => s.Id == BpStageProcess.NextStage.Id).First();
            }
        }

    }
}
