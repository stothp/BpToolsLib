using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpTools
{
    public class StageChoice : Stage, ITraversable, IExpressionHolder
    {
        public string GroupId { get; set; } = System.Guid.NewGuid().ToString();
        public Collection<Choice> Choices { get; set; } = new Collection<Choice>();
        public StageChoiceEnd ChoiceEnd { get; set; }
        public StageSet NextStages
        {
            get
            {
                StageSet stageSet = new StageSet();

                if (Choices != null)
                {
                    foreach (Choice choice in Choices)
                    {
                        stageSet.UnionWith(choice.NextStages);
                    }
                }

                if (ChoiceEnd != null)
                {
                    stageSet.Add((Stage)ChoiceEnd);
                }
                return stageSet;
            }
        }

        public MutableExpressionSet Expressions
        {
            get
            {
                MutableExpressionSet exs = new MutableExpressionSet();
                foreach (Choice choice in Choices)
                {
                    exs.UnionWith(choice.Expressions);
                }
                return exs;
            }
        }

        public StageChoice() : base("Choice", Stage.StageType.ChoiceStart)
        {
            ChoiceEnd = new StageChoiceEnd(GroupId);
        }
        public StageChoice(string name) : this()
        {
            Name = name;
        }
    }
}
