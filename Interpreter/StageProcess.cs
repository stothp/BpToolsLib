using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.Interpreter
{
    public class StageProcess : Stage, ITraversable
    {
        public BpTools.StageProcess BpStageProcess
        { 
            get 
            { 
                return (BpTools.StageProcess)base.BpStage; 
            } 
        }

        public StageProcess(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpTools.StageProcess();
            Initialize();
        }

        public override BpTools.Stage GetStage()
        {
            foreach (XmlClasses.Input xmlInput in XmlStage.Inputs)
            {
                BpTools.InputParameter parameter =
                    new BpTools.InputParameter(
                        DataTypeConverter.GetDataTypeByName(xmlInput.Type)
                        , xmlInput.Name
                        , xmlInput.Narrative
                        , xmlInput.Expr);
                BpStageProcess.InputParameters.Add(parameter);
            }
            foreach (XmlClasses.Output xmlOutput in XmlStage.Outputs)
            {
                BpTools.OutputParameter parameter =
                    new BpTools.OutputParameter(
                        DataTypeConverter.GetDataTypeByName(xmlOutput.Type)
                        , xmlOutput.Name
                        , xmlOutput.Narrative
                        , xmlOutput.Stage);
                BpStageProcess.OutputParameters.Add(parameter);
            }
            BpStageProcess.Process = new BpTools.Process()
            {
                Id = XmlStage.ProcessId
            };
            if (XmlStage.OnSuccess != null)
            {
                BpStageProcess.NextStage = new BpTools.StageReference(XmlStage.OnSuccess);
            }
            return BpStage;
        }

        public void SetNextStages(BpTools.StageSet set)
        {
            if (BpStageProcess.NextStage != null)
            {
                BpStageProcess.NextStage = set.Where(s => s.Id == BpStageProcess.NextStage.Id).First();
            }
        }

    }
}
