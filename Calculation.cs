using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BpTools
{
    public class Calculation : IExpressionHolder, IDataNameHolder
    {
        private MutableExpression MutableExpression { get; } = new MutableExpression();
        private MutableDataName MutableDataName { get; } = new MutableDataName();
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

        public string DataName
        {
            get
            {
                return MutableDataName.Value;
            }

            set
            {
                MutableDataName.Value = value;
            }
        }

        public MutableExpressionSet Expressions
        {
            get
            {
                return new MutableExpressionSet() { MutableExpression };
            }
        }

        public MutableDataNameSet DataNames
        {
            get
            {
                return new MutableDataNameSet() { MutableDataName };
            }
        }


        public Calculation()
        {
        }

        public Calculation(string expression, string stageName)
        {
            Expression = expression;
            DataName = stageName;
        }
    }
}
