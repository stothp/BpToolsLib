using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.Interpreter
{
    public class StageChoice : Stage, ITraversable
    {
        public BpTools.StageChoice BpStageChoice
        { 
            get 
            { 
                return (BpTools.StageChoice)base.BpStage; 
            } 
        }

        public StageChoice(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpTools.StageChoice();
            Initialize();
        }

        public override BpTools.Stage GetStage()
        {
            BpStageChoice.GroupId = XmlStage.GroupId;
            BpStageChoice.ChoiceEnd.GroupId = XmlStage.GroupId;
            foreach (XmlClasses.Choice choice in XmlStage.Choices)
            {
                BpStageChoice.Choices.Add(new BpTools.Choice(choice.Name, choice.Expression, choice.Distance, new BpTools.StageReference(choice.OnTrue)));
            }

            return BpStage;
        }

        public void SetNextStages(BpTools.StageSet set)
        {
            foreach (BpTools.Choice choice in BpStageChoice.Choices)
            {
                if (choice.OnTrue != null)
                {
                    choice.OnTrue = set.Where(s => s.Id == choice.OnTrue.Id).First();
                }
            }
            if (BpStageChoice.GroupId != null)
            {
                BpStageChoice.ChoiceEnd = (BpTools.StageChoiceEnd)set.Where(s => s is BpTools.StageChoiceEnd && ((BpTools.StageChoiceEnd)s).GroupId == BpStageChoice.GroupId).First();
            }
        }

    }
}
