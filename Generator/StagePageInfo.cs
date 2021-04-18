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
    public class StagePageInfo : Stage
    {
        readonly BpToolsLib.StagePageInfo stage;

        public StagePageInfo(BpToolsLib.StagePageInfo stage, string subsheetId) : base(stage, subsheetId)
        {
            this.stage = stage;
        }

        public override XmlClasses.Stage GetBpStage()
        {
            XmlClasses.Stage bpStage = base.GetBpStage();

            return bpStage;
        }
    }
}
