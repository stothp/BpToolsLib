using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using BpTools;
using BpTools.XmlClasses;
using BpTools.Interpreter;

namespace BpTools.Generator
{
    public class StageChoice : Stage
    {
        readonly BpTools.StageChoice stage;

        public StageChoice(BpTools.StageChoice stage, string subsheetId) : base(stage, subsheetId)
        {
            this.stage = stage;
        }

        public override XmlClasses.Stage GetBpStage()
        {
            XmlClasses.Stage bpStage = base.GetBpStage();

            bpStage.GroupId = stage.GroupId;

            bpStage.Choices = new List<XmlClasses.Choice>();
            foreach (BpTools.Choice choice in stage.Choices)
            {
                bpStage.Choices.Add(
                    new XmlClasses.Choice()
                    {
                        Name = choice.Name,
                        Distance = choice.Distance,
                        Expression = choice.Expression,
                        OnTrue = choice.OnTrue != null ? choice.OnTrue.Id : null
                    }
                );
            }

            return bpStage;
        }
    }
}
