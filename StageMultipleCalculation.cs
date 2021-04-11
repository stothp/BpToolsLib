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
                MutableExpressionSet exs = new MutableExpressionSet();
                foreach (Calculation calc in Calculations)
                {
                    exs.UnionWith(calc.Expressions);
                }
                return exs;
            }
        }

        public MutableDataNameSet DataNames
        {
            get
            {
                MutableDataNameSet dns = new MutableDataNameSet();
                foreach (Calculation calc in Calculations)
                {
                    dns.UnionWith(calc.DataNames);
                }
                return dns;
            }
        }

        public StageMultipleCalculation() : base("MultiCalc", Stage.StageType.MultipleCalculation) { }
    }
}
