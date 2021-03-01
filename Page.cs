using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools
{
    // Subsheet
    public class Page : BpElement
    {
        public string Id { get; set; } = System.Guid.NewGuid().ToString();
        public string Type { get; set; } = "Normal";
        public bool Published { get; set; } = false;
        public string Name { get; set; } = "";
        public View View { get; set; } = new View();

        public PageInformation PageInformation { get; set; }
        public Start Start { get; set; }
        public StageCollection OtherStages { get; } = new StageCollection();

        public Page(string name)
        {
            Name = name;
            PageInformation = new PageInformation(Name);
            Start = new Start();
        }

        public Page(string name, bool published) : this(name)
        {
            Published = published;
        }

        public HashSet<Stage> GetAllStages()
        {
            HashSet<Stage> stages = new HashSet<Stage>();
            stages.Add(PageInformation);
            stages.UnionWith(StageTraversal.GetTraversedStages(Start));
            stages.UnionWith(OtherStages);

            return stages;
        }
    }
}
