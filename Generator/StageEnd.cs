using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using BpTools;
using BpTools.Interpreter;

namespace BpTools.Generator
{
    public class StageEnd : Stage
    {
        readonly BpTools.StageEnd stage;

        public StageEnd(BpTools.StageEnd stage, string subsheetId) : base(stage, subsheetId)
        {
            this.stage = stage;
        }

        public override XmlClasses.Stage GetBpStage()
        {
            XmlClasses.Stage bpStage = base.GetBpStage();

            bpStage.Outputs = new List<XmlClasses.Output>();

            foreach (BpTools.EndParameter param in stage.OutputParameters)
            {
                bpStage.Outputs.Add(new EndParameter(param).GetOutput());
            }
            
            return bpStage;
        }
    }
}
