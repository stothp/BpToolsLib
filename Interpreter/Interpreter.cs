using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace BpToolsLib.Interpreter
{
    public class Interpreter
    {
        public XmlClasses.Process Process { get; set; }

        public Interpreter(XmlClasses.Process process)
        {
            Process = process;
        }

        public Interpreter(string xml)
        {
            XmlSerializer ser = new XmlSerializer(typeof(XmlClasses.Process));

            XmlClasses.Process proc;

            byte[] byteArray = Encoding.UTF8.GetBytes(xml);
            MemoryStream stream = new MemoryStream(byteArray);

            using (Stream reader = stream)
            {
                Process = (XmlClasses.Process)ser.Deserialize(reader);
            }
        }

        private BpToolsLib.Process GetProcess()
        {
            BpToolsLib.Process process = new Process(Process).GetProcess();
            //foreach (XmlClasses.Subsheet bpSubsheet in Process.Subsheets)
            //{
            //    BpTools.Page page = new Page(bpSubsheet).GetPage();
            //    process.Pages.Add(page);

            //    foreach (XmlClasses.Stage bpStage in Process.Stages.Where(s => s.SubsheetId == page.Id))
            //    {
            //        BpTools.Stage stage = new StageFactory(bpStage).GetStage();
            //        page.Stages.Add(stage);
            //        if (stage is BpTools.StageStart)
            //        {
            //            page.Start = (BpTools.StageStart)stage;
            //        }
            //        else if (stage is BpTools.StagePageInfo)
            //        {
            //            page.PageInformation = (BpTools.StagePageInfo)stage;
            //        }
            //    }

            //    foreach (BpTools.Stage stage in page.AllStages)
            //    {
            //        if (stage is ITraversable)
            //        {
            //            ((ITraversable)stage).SetNextStages(page.AllStages);
            //        }
            //    }
            //}

            return process;
        }

        private BpToolsLib.StageSet GetStageSet()
        {
            List<Stage> stages = new List<Stage>();
            BpToolsLib.StageSet stageSet = new StageSet();

            foreach (XmlClasses.Stage bpStage in Process.Stages)
            {
                Stage stage = new StageFactory(bpStage).GetStage();
                stageSet.Add(stage.GetStage());
                stages.Add(stage);
            }

            foreach (Stage stage in stages)
            {
                if (stage is ITraversable)
                {
                    ((ITraversable)stage).SetNextStages(stageSet);
                }
            }

            return stageSet;
        }

        public BpToolsLib.IBaseElement GetElement()
        {
            if (Process.Subsheets != null && Process.Subsheets.Count > 0)
            {
                return GetProcess();
            } 
            else
            {
                return GetStageSet();
            }
        }
    }
}
