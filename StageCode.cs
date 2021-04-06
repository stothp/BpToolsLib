using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BpTools
{
    public class StageCode: Stage, ITraversable
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

        public MutableExpressionSet Expressions
        {
            get
            {
                return (MutableExpressionSet)InputParameters.Select(p => p.Expression);
            }
        }
        public MutableDataNameSet DataNames
        {
            get
            {
                return (MutableDataNameSet)OutputParameters.Select(p => p.DataName);
            }
        }

        public Collection<InputParameter> InputParameters { get; set; } = new Collection<InputParameter>();
        public Collection<OutputParameter> OutputParameters { get; set; } = new Collection<OutputParameter>();
        public string Code { get; set; }

        public StageCode() : base("Code", Stage.StageType.Code) { }

    }
}
