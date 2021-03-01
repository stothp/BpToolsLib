using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools
{
    public abstract class Stage : BpElement
    {
        public enum StageType
        {
            Action,
            Alert,
            Anchor,
            Block,
            Calculation,
            Choice,
            ChoiceEnd,
            Collection,
            Data,
            Decision,
            End,
            Exception,
            LoopEnd,
            LoopStart,
            MultipleCalculation,
            Note,
            Process,
            ProcessInfo,
            Recover,
            Resume,
            Start,
            SubSheet,
            SubsheetInfo
        }

        public string Id { get; set; } = System.Guid.NewGuid().ToString();
        public string Name { get; set; } = "";
        public StageType Type { get; }
        public string Description { get; set; } = "";
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public int Width { get; set; } = 60;
        public int Height { get; set; } = 30;
        public Font Font = new Font();

        public Stage(string name, StageType type)
        {
            Name = name;
            Type = type;
        }

    }
}
