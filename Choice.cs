using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools
{
    public class Choice : ITraversable, IExpressionHolder
    {
        public string Name { get; set; } = "";
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

        public double Distance { get; set; } = 0;
        public Stage OnTrue { get; set; }
        public StageSet NextStages
        {
            get
            {
                return
                    OnTrue == null
                    ? new StageSet()
                    : new StageSet() { OnTrue };
            }
        }

        public Choice()
        {
        }

        public Choice(string name, string expression, double distance, Stage onTrue) : this()
        {
            Name = name;
            Expression = expression;
            Distance = distance;
            OnTrue = onTrue;
        }
    }
}
