using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.Interpreter
{
    public class StageCode : Stage, ITraversable
    {
        public BpTools.StageCode BpStageCode
        { 
            get 
            { 
                return (BpTools.StageCode)base.BpStage; 
            } 
        }

        public StageCode(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpTools.StageCode();
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
                BpStageCode.InputParameters.Add(parameter);
            }
            foreach (XmlClasses.Output xmlOutput in XmlStage.Outputs)
            {
                BpTools.OutputParameter parameter =
                    new BpTools.OutputParameter(
                        DataTypeConverter.GetDataTypeByName(xmlOutput.Type)
                        , xmlOutput.Name
                        , xmlOutput.Narrative
                        , xmlOutput.Stage);
                BpStageCode.OutputParameters.Add(parameter);
            }
            BpStageCode.Code = XmlStage.Code;
            if (XmlStage.OnSuccess != null)
            {
                BpStageCode.NextStage = new BpTools.StageReference(XmlStage.OnSuccess);
            }
            return BpStage;
        }

        public void SetNextStages(BpTools.StageSet set)
        {
            if (BpStageCode.NextStage != null)
            {
                BpStageCode.NextStage = set.Where(s => s.Id == BpStageCode.NextStage.Id).First();
            }
        }

    }
}
