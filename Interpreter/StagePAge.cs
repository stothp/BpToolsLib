using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib.Interpreter
{
    public class StagePage : Stage, ITraversable
    {
        public BpToolsLib.StagePage BpStagePage
        { 
            get 
            { 
                return (BpToolsLib.StagePage)base.BpStage; 
            } 
        }

        public StagePage(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpToolsLib.StagePage();
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
                BpStagePage.InputParameters.Add(parameter);
            }
            foreach (XmlClasses.Output xmlOutput in XmlStage.Outputs)
            {
                BpToolsLib.OutputParameter parameter =
                    new BpToolsLib.OutputParameter(
                        DataTypeConverter.GetDataTypeByName(xmlOutput.Type)
                        , xmlOutput.Name
                        , xmlOutput.Narrative
                        , xmlOutput.Stage);
                BpStagePage.OutputParameters.Add(parameter);
            }
            BpStagePage.Page = new BpToolsLib.Page()
            {
                Id = XmlStage.ProcessId
            };
            if (XmlStage.OnSuccess != null)
            {
                BpStagePage.NextStage = new BpToolsLib.StageReference(XmlStage.OnSuccess);
            }
            return BpStage;
        }

        public void SetNextStages(BpToolsLib.StageSet set)
        {
            if (BpStagePage.NextStage != null)
            {
                BpStagePage.NextStage = set.Where(s => s.Id == BpStagePage.NextStage.Id).First();
            }
        }

    }
}
