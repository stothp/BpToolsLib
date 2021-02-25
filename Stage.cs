using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools
{
    abstract class Stage : BpElement
    {
        public string StageId { get; set; } = System.Guid.NewGuid().ToString();
        public string Name { get; set; } = "";
        public string Type { get; set; } = "";
        public string Narrative { get; set; } = "";
        public int DisplayX { get; set; } = 0;
        public int DisplayY { get; set; } = 0;
        public int DisplayWidth { get; set; } = 60;
        public int DisplayHeight { get; set; } = 30;
        public Font Font = new Font("Segoe UI", 10, "Regular", "000000");

        public Stage(string name, string type)
        {
            Name = name;
            Type = type;
        }

    }
}
