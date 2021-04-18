using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using BpToolsLib;


namespace BpToolsLib.Generator
{
    public class StageSet
    {
        BpToolsLib.StageSet stageSet;
        string subsheetId = null;

        public StageSet(BpToolsLib.StageSet stageSet)
        {
            this.stageSet = stageSet;
        }

        public StageSet(BpToolsLib.StageSet stageSet, string subsheetId) : this (stageSet)
        {
            this.subsheetId = subsheetId;
        }

        public virtual List<XmlClasses.Stage> GetBpStage ()
        {
            List<XmlClasses.Stage> bpStage = new List<XmlClasses.Stage>();

            foreach (BpToolsLib.Stage stage in stageSet)
            {
                bpStage.Add(StageFactory.GetObject(stage, subsheetId).GetBpStage());
            }

            return bpStage;
        }
    }
}
