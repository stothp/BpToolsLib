using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib
{
    // Subsheet
    public class Page : IBaseElement
    {
        public string Id { get; set; } = System.Guid.NewGuid().ToString();
        public string Type { get; set; } = "Normal";
        public bool Published { get; set; } = false;
        public string Name { get; set; } = "";
        public View View { get; set; } = new View();
        public StageSet AllStages
        {
            get
            {
                StageSet all = (StageSet)TraverseStages.GetTraversedStages(Start);
                all.UnionWith(new StageSet() { PageInformation });
                return all;
            }
        }

        public StagePageInfo PageInformation { get; set; }
        public StageStart Start { get; set; }
        public StageSet Stages { get; set; } = new StageSet();

        public Page() { }

        public Page(string name)
        {
            Name = name;
            PageInformation = new StagePageInfo(Name);
            Start = new StageStart();
        }

        public Page(string name, bool published) : this(name)
        {
            Published = published;
        }

    }
}
