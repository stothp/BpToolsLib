using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpTools
{
    public class StageNote : Stage, ITraversable
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

        public StageNote() : base("Note", Stage.StageType.Note) { }
        public StageNote(string name) : base(name, Stage.StageType.Note) { }
        public StageNote(string name, string description) : base(name, description, Stage.StageType.Note) { }
    }
}
