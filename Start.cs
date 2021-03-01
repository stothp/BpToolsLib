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
    public class Start : Stage, ILeavable, ITraversable
    {
        public Stage NextStage { get; set; }
        public Collection<Stage> NextStages { get { return new Collection<Stage>(new Stage[] { NextStage }); } }
        public InputParameterCollection InputParameters { get; } = new InputParameterCollection();

        public Start() : base("Start", Stage.StageType.Start) { }

    }
}
