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
    public class StageStart : Stage, ITraversable, IDataNameHolder
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

        public MutableDataNameSet DataNames
        {
            get
            {
                MutableDataNameSet dataNames = new MutableDataNameSet();
                foreach (StartParameter parameter in InputParameters)
                {
                    dataNames.UnionWith(parameter.DataNames);
                }
                return dataNames;
            }
        }

        public Collection<StartParameter> InputParameters { get; set; } = new Collection<StartParameter>();

        public StageStart() : base("Start", Stage.StageType.Start) { }

    }
}
