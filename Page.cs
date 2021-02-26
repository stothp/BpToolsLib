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
        public string Type { get; set; } = "Normal";
        public bool Published { get; set; } = false;
        public string Name { get; set; } = "";
        public View View { get; set; } = new View();

        public SubSheetInfo SubSheetInfo { get; set; }
        public StageCollection Stages { get; } = new StageCollection();

        public Page(string name)
        {
            Name = name;
            SubSheetInfo = new SubSheetInfo(Name);
        }

        public Page (string name, bool published) : this (name)
        {
            Published = published;
        }
    }
}
