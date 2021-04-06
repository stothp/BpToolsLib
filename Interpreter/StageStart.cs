using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.Interpreter
{
    public class StageStart : Stage, ITraversable
    {
        public BpTools.StageStart BpStageStart 
        { 
            get 
            { 
                return (BpTools.StageStart)base.BpStage; 
            } 
        }

        public StageStart(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpTools.StageStart();
            Initialize();
        }

        public override BpTools.Stage GetStage()
        {
            foreach (XmlClasses.Input xmlInput in XmlStage.Inputs)
            {
                BpTools.StartParameter parameter =
                    new BpTools.StartParameter(
                        DataTypeConverter.GetDataTypeByName(xmlInput.Type)
                        , xmlInput.Name
                        , xmlInput.Narrative
                        , xmlInput.Stage);
                BpStageStart.InputParameters.Add(parameter);
            }

            if (XmlStage.OnSuccess != null)
            {
                BpStageStart.NextStage = new BpTools.StageReference(XmlStage.OnSuccess);
            }

            return this.BpStage;
        }

        public void SetNextStages(BpTools.StageSet set)
        {
            if (BpStageStart.NextStage != null)
            {
                BpStageStart.NextStage = set.Where(s => s.Id == BpStageStart.NextStage.Id).First();
            }
        }

    }
}
