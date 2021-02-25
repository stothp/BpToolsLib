using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools
{
    // Subsheet
    class Page : BpElement
    {
        public string StageId { get; set; } = System.Guid.NewGuid().ToString();
        public string Type { get; set; } = "normal";
        public bool Published { get; set; } = false;
        public string Name { get; set; } = "";
        public View View { get; set; } = new View();

        public Collection<Stage> Stages { get; } = new Collection<Stage>();

        public Page(string name)
        {
            Name = name;
        }

        public Page (string name, bool published)
        {
            Name = name;
            Published = published;
        }
    }
}
