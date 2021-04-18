using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib.Interpreter
{
    public class Process
    {
        private XmlClasses.Process bpProcess;

        public Process (XmlClasses.Process bpProcess)
        {
            this.bpProcess = bpProcess;
        }

        public BpToolsLib.Process GetProcess()
        {
            BpToolsLib.Process process = new BpToolsLib.Process();
            process.Id = bpProcess.PreferredId;
            process.Name = bpProcess.Name;
            process.Version = bpProcess.Version;
            process.BpVersion = bpProcess.BpVersion;
            process.Description = bpProcess.Narrative;
            process.ByRefCollection = bpProcess.ByRefCollection;

            return process;
        }

    }
}
