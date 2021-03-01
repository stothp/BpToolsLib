using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools
{
    public class End : Stage, ITraversable
    {
        public Collection<Stage> NextStages { get { return new Collection<Stage>(); } }

        public End() : base("End", StageType.End) { }
        public OutputParameterCollection OutputParameters { get; set; } = new OutputParameterCollection();

    }
}
