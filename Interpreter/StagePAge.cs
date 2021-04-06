using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.Interpreter
{
    public class StagePage : Stage, ITraversable
    {
        public BpTools.StagePage BpStagePage
        { 
            get 
            { 
                return (BpTools.StagePage)base.BpStage; 
            } 
        }

        public StagePage(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpTools.StagePage();
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
                BpStagePage.InputParameters.Add(parameter);
            }
            foreach (XmlClasses.Output xmlOutput in XmlStage.Outputs)
            {
                BpTools.OutputParameter parameter =
                    new BpTools.OutputParameter(
                        DataTypeConverter.GetDataTypeByName(xmlOutput.Type)
                        , xmlOutput.Name
                        , xmlOutput.Narrative
                        , xmlOutput.Stage);
                BpStagePage.OutputParameters.Add(parameter);
            }
            BpStagePage.Page = new BpTools.Page()
            {
                Id = XmlStage.ProcessId
            };
            if (XmlStage.OnSuccess != null)
            {
                BpStagePage.NextStage = new BpTools.StageReference(XmlStage.OnSuccess);
            }
            return BpStage;
        }

        public void SetNextStages(BpTools.StageSet set)
        {
            if (BpStagePage.NextStage != null)
            {
                BpStagePage.NextStage = set.Where(s => s.Id == BpStagePage.NextStage.Id).First();
            }
        }

    }
}
