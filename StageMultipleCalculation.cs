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
    public class StageMultipleCalculation: Stage, ITraversable, IExpressionHolder, IDataNameHolder
    {
        public Collection<Calculation> Calculations { get; set; } = new Collection<Calculation>();

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

        public MutableExpressionSet Expressions
        {
            get
            {
                return (MutableExpressionSet)Calculations.Select(p => p.Expression);
            }
        }

        public MutableDataNameSet DataNames
        {
            get
            {
                return (MutableDataNameSet)Calculations.Select(p => p.DataName);
            }
        }

        public StageMultipleCalculation() : base("MultiCalc", Stage.StageType.MultipleCalculation) { }
    }
}
