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
    public class StageLoopEnd : Stage, ITraversable
    {
        public string GroupId { get; set; } = "";
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

        public StageLoopEnd() : base("Loop End", Stage.StageType.LoopEnd) { }
        public StageLoopEnd(string groupId) : this() {
            GroupId = groupId;
        }
    }
}
