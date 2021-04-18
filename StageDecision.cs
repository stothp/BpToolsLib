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
    public class StageDecision : Stage, ITraversable, IExpressionHolder
    {
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

        public Stage OnTrue { get; set; }
        public Stage OnFalse { get; set; }
        public StageSet NextStages
        {
            get
            {
                StageSet stageset = new StageSet();
                if (OnTrue != null)
                {
                    stageset.Add(OnTrue);
                }
                if (OnFalse != null)
                {
                    stageset.Add(OnFalse);
                }
                return stageset;
            }
        }

        public StageDecision() : base("Decision", Stage.StageType.Decision) { }
        public StageDecision(string expression) : this() {
            Expression = expression;
        }
    }
}
