using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib.Interpreter
{
    public class StageChoice : Stage, ITraversable
    {
        public BpToolsLib.StageChoice BpStageChoice
        { 
            get 
            { 
                return (BpToolsLib.StageChoice)base.BpStage; 
            } 
        }

        public StageChoice(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpToolsLib.StageChoice();
            Initialize();
        }

        public override BpToolsLib.Stage GetStage()
        {
            BpStageChoice.GroupId = XmlStage.GroupId;
            BpStageChoice.ChoiceEnd.GroupId = XmlStage.GroupId;
            foreach (XmlClasses.Choice choice in XmlStage.Choices)
            {
                BpStageChoice.Choices.Add(new BpToolsLib.Choice(choice.Name, choice.Expression, choice.Distance, new BpToolsLib.StageReference(choice.OnTrue)));
            }

            return BpStage;
        }

        public void SetNextStages(BpToolsLib.StageSet set)
        {
            foreach (BpToolsLib.Choice choice in BpStageChoice.Choices)
            {
                if (choice.OnTrue != null)
                {
                    choice.OnTrue = set.Where(s => s.Id == choice.OnTrue.Id).First();
                }
            }
            if (BpStageChoice.GroupId != null)
            {
                BpStageChoice.ChoiceEnd = (BpToolsLib.StageChoiceEnd)set.Where(s => s is BpToolsLib.StageChoiceEnd && ((BpToolsLib.StageChoiceEnd)s).GroupId == BpStageChoice.GroupId).First();
            }
        }

    }
}
