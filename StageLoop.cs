using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BpToolsLib
{
    public class StageLoop : Stage, ITraversable, IDataNameHolder
    {
        public string GroupId { get; set; } = System.Guid.NewGuid().ToString();
        public string LoopType { get; set; } = "ForEach";
        private MutableDataName MutableCollectionName { get; } = new MutableDataName();
        public string LoopCollectionName
        {
            get
            {
                return MutableCollectionName.Value;
            }

            set
            {
                MutableCollectionName.Value = value;
            }
        }

        public MutableDataNameSet DataNames
        {
            get
            {
                return new MutableDataNameSet() { MutableCollectionName };
            }
        }


        public StageLoopEnd LoopEnd { get; set; }
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

        public StageLoop() : base("Loop Start1", Stage.StageType.LoopStart) {
            LoopEnd = new StageLoopEnd(GroupId);
        }

        public StageLoop(string name) : this()
        {
            Name = name;
        }

        public StageLoop(string name, string loopCollectionName) : this(name) {
            LoopCollectionName = loopCollectionName;
        }
    }
}
