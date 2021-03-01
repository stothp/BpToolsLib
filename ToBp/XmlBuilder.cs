using BpTools.BpClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BpTools.ToBp
{
    public static class XmlBuilder
    {
        public static BpClasses.Process BuildXmlProcess(BpTools.BpElement element)
        {
            if (element is BpTools.Process)
            {
                return ProcessToProcess((BpTools.Process)element);
            }
            else if (element is BpTools.Page)
            {
                return PageToProcess((BpTools.Page)element);
            }
            else if (element is BpTools.StageCollection)
            {
                return StageCollectionToProcess((BpTools.StageCollection)element);
            }
            else
            {
                throw new System.Exception("Invalid element to generate XML from");
            }
        }

        public static BpClasses.Process ProcessToProcess(BpTools.Process process)
        {
            BpClasses.Process xmlProc = Process.getXmlProcess(process);
            xmlProc.Subsheets = PagesToSubsheets(process.Pages);

            xmlProc.Stages = new List<BpClasses.Stage>();
            foreach (BpTools.Page page in (process.Pages))
            {
                xmlProc.Stages.AddRange(PageToStages(page));
            }

            return xmlProc;
        }

        public static BpClasses.Process PageToProcess(BpTools.Page page)
        {
            BpClasses.Process xmlProc = Process.getXmlProcess(new BpTools.Process("__selection__part"));
            xmlProc.Subsheets = new List<BpClasses.Subsheet>();
            xmlProc.Subsheets.Add(Page.getXmlSubsheet(page));

            xmlProc.Stages = new List<BpClasses.Stage>();
            xmlProc.Stages.AddRange(PageToStages(page));
            return xmlProc;
        }

        public static BpClasses.Process StageCollectionToProcess(BpTools.StageCollection collection)
        {
            BpClasses.Process xmlProc = Process.getXmlProcess(new BpTools.Process("__selection__part"));

            HashSet<BpTools.Stage> stages = new HashSet<BpTools.Stage>();
            foreach (BpTools.Stage stage in (collection))
            {
                stages.Add(stage);
                if (stage is BpTools.ITraversable)
                {
                    stages.UnionWith(BpTools.StageTraversal.GetTraversedStages((ITraversable)stage));
                }
            }

            xmlProc.Stages = new List<BpClasses.Stage>();
            foreach (BpTools.Stage stage in stages)
            {
                xmlProc.Stages.Add(StageFactory.getXmlObj(stage, null));
            }
            return xmlProc;
        }

        public static List<BpClasses.Subsheet> PagesToSubsheets(Collection<BpTools.Page> pages)
        {
            List<BpClasses.Subsheet> subsheets = new List<BpClasses.Subsheet>();

            foreach (BpTools.Page page in pages)
            {
                subsheets.Add(Page.getXmlSubsheet(page));
            }

            return subsheets;
        }

        public static List<BpClasses.Stage> PageToStages(BpTools.Page page)
        {
            List<BpClasses.Stage> stages = new List<BpClasses.Stage>();

            stages.Add(PageInformation.getXmlObj(page.PageInformation, page.Id));

            foreach (BpTools.Stage stage in page.OtherStages)
            {
                stages.Add(StageFactory.getXmlObj(stage, page.Id));
            }

            foreach (BpTools.Stage stage in BpTools.StageTraversal.GetTraversedStages(page.Start))
            {
                stages.Add(StageFactory.getXmlObj(stage, page.Id));
            }

            return stages;
        }

    }
}