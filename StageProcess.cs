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
    public class StageProcess: Stage, ITraversable, IExpressionHolder, IDataNameHolder
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
                MutableExpressionSet dataNames = new MutableExpressionSet();
                foreach (InputParameter parameter in InputParameters)
                {
                    dataNames.UnionWith(parameter.Expressions);
                }
                return dataNames;
            }
        }

        public MutableDataNameSet DataNames
        {
            get
            {
                MutableDataNameSet dataNames = new MutableDataNameSet();
                foreach (OutputParameter parameter in OutputParameters)
                {
                    dataNames.UnionWith(parameter.DataNames);
                }
                return dataNames;
            }
        }

        public Collection<InputParameter> InputParameters { get; set; } = new Collection<InputParameter>();
        public Collection<OutputParameter> OutputParameters { get; set; } = new Collection<OutputParameter>();
        public Process Process { get; set; }

        public StageProcess() : base("Process", Stage.StageType.Process)
        {
        }

        public StageProcess(Process process) : this() {
            Process = process;
        }

    }
}
