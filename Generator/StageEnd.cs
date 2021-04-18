using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using BpToolsLib;
using BpToolsLib.Interpreter;

namespace BpToolsLib.Generator
{
    public class StageEnd : Stage
    {
        readonly BpToolsLib.StageEnd stage;

        public StageEnd(BpToolsLib.StageEnd stage, string subsheetId) : base(stage, subsheetId)
        {
            this.stage = stage;
        }

        public override XmlClasses.Stage GetBpStage()
        {
            XmlClasses.Stage bpStage = base.GetBpStage();

            bpStage.Outputs = new List<XmlClasses.Output>();

            foreach (BpToolsLib.EndParameter param in stage.OutputParameters)
            {
                bpStage.Outputs.Add(new EndParameter(param).GetOutput());
            }
            
            return bpStage;
        }
    }
}
