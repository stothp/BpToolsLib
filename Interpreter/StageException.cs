using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.Interpreter
{
    public class StageException : Stage, ITraversable
    {
        public BpTools.StageException BpStageException
        { 
            get 
            { 
                return (BpTools.StageException)base.BpStage; 
            } 
        }

        public StageException(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpTools.StageException();
            Initialize();
        }

        public override BpTools.Stage GetStage()
        {
            BpStageException.ExceptionType = XmlStage.Exception.Type;
            BpStageException.ExceptionDetail = XmlStage.Exception.Detail;
            BpStageException.PreserveCurrentException = XmlStage.Exception.UseCurrent == "yes";
            BpStageException.SaveScreenCapture = XmlStage.Exception.SaveScreenCapture == "yes";
            return BpStage;
        }

        public void SetNextStages(BpTools.StageSet set)
        {
        }

    }
}
