using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.Interpreter
{
    public class StageAction : Stage, ITraversable
    {
        public BpTools.StageAction BpStageAction
        { 
            get 
            { 
                return (BpTools.StageAction)base.BpStage; 
            } 
        }

        public StageAction(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpTools.StageAction();
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
                BpStageAction.InputParameters.Add(parameter);
            }
            foreach (XmlClasses.Output xmlOutput in XmlStage.Outputs)
            {
                BpTools.OutputParameter parameter =
                    new BpTools.OutputParameter(
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
                BpStageAction.NextStage = new BpTools.StageReference(XmlStage.OnSuccess);
            }
            return BpStage;
        }

        public void SetNextStages(BpTools.StageSet set)
        {
            if (BpStageAction.NextStage != null)
            {
                BpStageAction.NextStage = set.Where(s => s.Id == BpStageAction.NextStage.Id).First();
            }
        }

    }
}
