using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.Interpreter
{
    public class StageEnd : Stage, ITraversable
    {
        public BpTools.StageEnd BpStageEnd 
        { 
            get 
            { 
                return (BpTools.StageEnd)base.BpStage; 
            } 
        }

        public StageEnd(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpTools.StageEnd();
            Initialize();
        }

        public override BpTools.Stage GetStage()
        {
            foreach (XmlClasses.Output xmlOutput in XmlStage.Outputs)
            {
                BpTools.EndParameter parameter =
                    new BpTools.EndParameter(
                        DataTypeConverter.GetDataTypeByName(xmlOutput.Type)
                        , xmlOutput.Name
                        , xmlOutput.Narrative
                        , xmlOutput.Stage);
                BpStageEnd.OutputParameters.Add(parameter);
            }

            return this.BpStage;
        }

        public void SetNextStages(BpTools.StageSet set)
        {
        }

    }
}
