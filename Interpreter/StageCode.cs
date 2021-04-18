using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib.Interpreter
{
    public class StageCode : Stage, ITraversable
    {
        public BpToolsLib.StageCode BpStageCode
        { 
            get 
            { 
                return (BpToolsLib.StageCode)base.BpStage; 
            } 
        }

        public StageCode(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpToolsLib.StageCode();
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
                BpStageCode.InputParameters.Add(parameter);
            }
            foreach (XmlClasses.Output xmlOutput in XmlStage.Outputs)
            {
                BpToolsLib.OutputParameter parameter =
                    new BpToolsLib.OutputParameter(
                        DataTypeConverter.GetDataTypeByName(xmlOutput.Type)
                        , xmlOutput.Name
                        , xmlOutput.Narrative
                        , xmlOutput.Stage);
                BpStageCode.OutputParameters.Add(parameter);
            }
            BpStageCode.Code = XmlStage.Code;
            if (XmlStage.OnSuccess != null)
            {
                BpStageCode.NextStage = new BpToolsLib.StageReference(XmlStage.OnSuccess);
            }
            return BpStage;
        }

        public void SetNextStages(BpToolsLib.StageSet set)
        {
            if (BpStageCode.NextStage != null)
            {
                BpStageCode.NextStage = set.Where(s => s.Id == BpStageCode.NextStage.Id).First();
            }
        }

    }
}
