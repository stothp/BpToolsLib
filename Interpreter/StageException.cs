using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib.Interpreter
{
    public class StageException : Stage, ITraversable
    {
        public BpToolsLib.StageException BpStageException
        { 
            get 
            { 
                return (BpToolsLib.StageException)base.BpStage; 
            } 
        }

        public StageException(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpToolsLib.StageException();
            Initialize();
        }

        public override BpToolsLib.Stage GetStage()
        {
            BpStageException.ExceptionType = XmlStage.Exception.Type;
            BpStageException.ExceptionDetail = XmlStage.Exception.Detail;
            BpStageException.PreserveCurrentException = XmlStage.Exception.UseCurrent == "yes";
            BpStageException.SaveScreenCapture = XmlStage.Exception.SaveScreenCapture == "yes";
            return BpStage;
        }

        public void SetNextStages(BpToolsLib.StageSet set)
        {
        }

    }
}
