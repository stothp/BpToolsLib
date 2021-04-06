using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpTools
{
    public class StageAlert : Stage, ITraversable, IExpressionHolder
    {
        public Stage NextStage { get; set; }
        public StageSet NextStages
        {
            get
            {
                return
                    NextStage == null
                    ? new StageSet()
                    : new StageSet() { NextStage };
            }
        }

        public MutableExpression MutableExpression { get; } = new MutableExpression();
        public string Expression
        {
            get
            {
                return MutableExpression.Value;
            }

            set
            {
                MutableExpression.Value = value;
            }
        }

        public MutableExpressionSet Expressions
        {
            get
            {
                return new MutableExpressionSet() { MutableExpression };
            }
        }

        public StageAlert() : base("Alert", Stage.StageType.Alert) { }
        public StageAlert(string name) : base(name, Stage.StageType.Alert) { }
        public StageAlert(string name, string expression) : this(name) {
            Expression = expression;
        }
    }
}
