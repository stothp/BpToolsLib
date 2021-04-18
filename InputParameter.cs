using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib
{
    public class InputParameter : Parameter, IExpressionHolder
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

        public InputParameter(DataType type, string name, string narrative, string expression) : base (type, name, narrative)
        {
            Expression = expression;
        }
    }
}
