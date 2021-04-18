using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib
{
    public abstract class Stage : IBaseElement
    {
        public enum StageType
        {
            Action,
            Alert,
            Anchor,
            Block,
            Calculation,
            ChoiceStart,
            ChoiceEnd,
            Code,
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
        public StageType Type { get; set; }
        public string Description { get; set; } = "";
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public int Width { get; set; } = 60;
        public int Height { get; set; } = 30;
        public Font Font { get; set; } = new Font();

        public Stage()
        {
        }

        public Stage(string name, StageType type)
        {
            Name = name;
            Type = type;
        }

        public Stage(string name, string description, StageType type) : this(name, type)
        {
            Description = description;
        }

    }
}
