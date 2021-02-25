namespace BpTools
{
    class Process : BpElement
    {
        public string Name { get; set; } = "";
        public string Version { get; set; } = "1.0";
        public string Bpversion { get; set; } = "6.2.1.4272";
        public string Narrative { get; set; } = "";
        public string ByRefCollection { get; set; } = "true";
        public string PreferredId { get; set; } = System.Guid.NewGuid().ToString();


    }
}
