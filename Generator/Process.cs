using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.Generator
{
    public class Process
    {
        BpTools.Process process;

        public Process (BpTools.Process process)
        {
            this.process = process;
        }

        public XmlClasses.Process GetBpProcess()
        {
            XmlClasses.Process bpProc = new XmlClasses.Process();

            bpProc.Name = process.Name;
            bpProc.Version = process.Version;
            bpProc.BpVersion = process.BpVersion;
            bpProc.Narrative = process.Description;
            bpProc.ByRefCollection = process.ByRefCollection;
            bpProc.PreferredId = process.Id;

            bpProc.Subsheets = new List<XmlClasses.Subsheet>();
            bpProc.Stages = new List<XmlClasses.Stage>();
            foreach (BpTools.Page page in process.Pages)
            {
                XmlClasses.Subsheet ss = new Page(page).GetBpSubsheet();
                bpProc.Subsheets.Add(ss);

                foreach (BpTools.Stage stage in page.AllStages)
                {
                    bpProc.Stages.Add(StageFactory.GetObject(stage, page.Id).GetBpStage());
                }
            }

            return bpProc;
        }
    }
}
