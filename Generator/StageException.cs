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
    public class StageException : Stage
    {
        readonly BpTools.StageException stage;

        public StageException(BpTools.StageException stage, string subsheetId) : base(stage, subsheetId)
        {
            this.stage = stage;
        }

        public override XmlClasses.Stage GetBpStage()
        {
            XmlClasses.Stage bpStage = base.GetBpStage();

            bpStage.Exception = new XmlClasses.Exception();
            bpStage.Exception.Type = stage.ExceptionType;
            bpStage.Exception.Detail = stage.ExceptionDetail;
            if (stage.PreserveCurrentException)
            {
                bpStage.Exception.UseCurrent = "yes";
            }
            if (stage.SaveScreenCapture)
            {
                bpStage.Exception.SaveScreenCapture = "yes";
            }

            return bpStage;
        }
    }
}
