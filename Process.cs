using System.Collections.ObjectModel;

namespace BpToolsLib
{
    public class Process : IBaseElement
    {
        public string Name { get; set; } = "";
        public string Version { get; set; } = "1.0";
        public string BpVersion { get; set; } = "6.10.1.35171";
        public string Description { get; set; } = "";
        public string ByRefCollection { get; set; } = "true";
        public string Id { get; set; } = System.Guid.NewGuid().ToString();

        public Collection<Page> Pages { get; } = new Collection<Page>();

        public Process() { }

        public Process (string name)
        {
            Name = name;
        }
    }
}
