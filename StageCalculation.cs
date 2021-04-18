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
    public class StageCalculation: Stage, ITraversable, IExpressionHolder, IDataNameHolder
    {
        public MutableExpression MutableExpression { get; } = new MutableExpression();
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

        public StageCalculation() : base("Calculation", Stage.StageType.Calculation) { }
        public StageCalculation(string name) : this()
        {
            Name = name;
        }
        public StageCalculation(string name, string expression, string stageName) : this() {
            Expression = expression;
            DataName = stageName;
        }
    }
}
