using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib.Interpreter
{
    public class StageEnd : Stage, ITraversable
    {
        public BpToolsLib.StageEnd BpStageEnd 
        { 
            get 
            { 
                return (BpToolsLib.StageEnd)base.BpStage; 
            } 
        }

        public StageEnd(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpToolsLib.StageEnd();
            Initialize();
        }

        public override BpToolsLib.Stage GetStage()
        {
            foreach (XmlClasses.Output xmlOutput in XmlStage.Outputs)
            {
                BpToolsLib.EndParameter parameter =
                    new BpToolsLib.EndParameter(
                        DataTypeConverter.GetDataTypeByName(xmlOutput.Type)
                        , xmlOutput.Name
                        , xmlOutput.Narrative
                        , xmlOutput.Stage);
                BpStageEnd.OutputParameters.Add(parameter);
            }

            return this.BpStage;
        }

        public void SetNextStages(BpToolsLib.StageSet set)
        {
        }

    }
}
