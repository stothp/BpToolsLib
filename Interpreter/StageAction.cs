using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib.Interpreter
{
    public class StageAction : Stage, ITraversable
    {
        public BpToolsLib.StageAction BpStageAction
        { 
            get 
            { 
                return (BpToolsLib.StageAction)base.BpStage; 
            } 
        }

        public StageAction(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpToolsLib.StageAction();
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
                BpStageAction.InputParameters.Add(parameter);
            }
            foreach (XmlClasses.Output xmlOutput in XmlStage.Outputs)
            {
                BpToolsLib.OutputParameter parameter =
                    new BpToolsLib.OutputParameter(
                        DataTypeConverter.GetDataTypeByName(xmlOutput.Type)
                        , xmlOutput.Name
                        , xmlOutput.Narrative
                        , xmlOutput.Stage);
                BpStageAction.OutputParameters.Add(parameter);
            }
            BpStageAction.ActionReference.Vbo = XmlStage.Resource.Object;
            BpStageAction.ActionReference.Page = XmlStage.Resource.Action;
            if (XmlStage.OnSuccess != null)
            {
                BpStageAction.NextStage = new BpToolsLib.StageReference(XmlStage.OnSuccess);
            }
            return BpStage;
        }

        public void SetNextStages(BpToolsLib.StageSet set)
        {
            if (BpStageAction.NextStage != null)
            {
                BpStageAction.NextStage = set.Where(s => s.Id == BpStageAction.NextStage.Id).First();
            }
        }

    }
}
