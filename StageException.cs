using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib
{
    public class StageException : Stage, ITraversable, IExpressionHolder
    {
        public StageSet NextStages { get { return new StageSet(); } }
        public string ExceptionType { get; set; }
        public MutableExpression MutableDetail { get; } = new MutableExpression();
        public string ExceptionDetail
        {
            get
            {
                return MutableDetail.Value;
            }

            set
            {
                MutableDetail.Value = value;
            }
        }
        public MutableExpressionSet Expressions
        {
            get
            {
                return new MutableExpressionSet() { MutableDetail };
            }
        }
        public bool PreserveCurrentException { get; set; } = false;
        public bool SaveScreenCapture { get; set; } = false;

        public StageException() : base("Exception", Stage.StageType.Exception) { }
        public StageException(string exceptionType, string detail) : this() {
            ExceptionType = exceptionType;
            ExceptionDetail = detail;
        }
    }
}
