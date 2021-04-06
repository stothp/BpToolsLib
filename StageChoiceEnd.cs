using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpTools
{
    public class StageChoiceEnd : Stage, ITraversable
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

        public StageChoiceEnd() : base("Otherwise", Stage.StageType.ChoiceEnd) { }
        public StageChoiceEnd(string groupId) : this() {
            GroupId = groupId;
        }
    }
}
