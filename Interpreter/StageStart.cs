using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib.Interpreter
{
    public class StageStart : Stage, ITraversable
    {
        public BpToolsLib.StageStart BpStageStart 
        { 
            get 
            { 
                return (BpToolsLib.StageStart)base.BpStage; 
            } 
        }

        public StageStart(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpToolsLib.StageStart();
            Initialize();
        }

        public override BpToolsLib.Stage GetStage()
        {
            foreach (XmlClasses.Input xmlInput in XmlStage.Inputs)
            {
                BpToolsLib.StartParameter parameter =
                    new BpToolsLib.StartParameter(
                        DataTypeConverter.GetDataTypeByName(xmlInput.Type)
                        , xmlInput.Name
                        , xmlInput.Narrative
                        , xmlInput.Stage);
                BpStageStart.InputParameters.Add(parameter);
            }

            if (XmlStage.OnSuccess != null)
            {
                BpStageStart.NextStage = new BpToolsLib.StageReference(XmlStage.OnSuccess);
            }

            return this.BpStage;
        }

        public void SetNextStages(BpToolsLib.StageSet set)
        {
            if (BpStageStart.NextStage != null)
            {
                BpStageStart.NextStage = set.Where(s => s.Id == BpStageStart.NextStage.Id).First();
            }
        }

    }
}
