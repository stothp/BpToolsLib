using BpToolsLib.XmlClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BpToolsLib
{
    public class StageAction: Stage, ITraversable, IExpressionHolder, IDataNameHolder
    {
        public Stage NextStage { get; set; }
        public StageSet NextStages
        {
            get
            {
                return
                    NextStage == null
                    ? new StageSet()
                    : new StageSet() { NextStage };
            }
        }

        public MutableExpressionSet Expressions
        {
            get
            {
                MutableExpressionSet dataNames = new MutableExpressionSet();
                foreach (InputParameter parameter in InputParameters)
                {
                    dataNames.UnionWith(parameter.Expressions);
                }
                return dataNames;
            }
        }

        public MutableDataNameSet DataNames
        {
            get
            {
                MutableDataNameSet dataNames = new MutableDataNameSet();
                foreach (OutputParameter parameter in OutputParameters)
                {
                    dataNames.UnionWith(parameter.DataNames);
                }
                return dataNames;
            }
        }

        public Collection<InputParameter> InputParameters { get; set; } = new Collection<InputParameter>();
        public Collection<OutputParameter> OutputParameters { get; set; } = new Collection<OutputParameter>();
        public Action ActionReference { get; set; } = new Action();

        public StageAction() : base("Action", Stage.StageType.Action) { }

        public StageAction(Action actionReference) : this() 
        {
            ActionReference = actionReference;
        }

        public StageAction(string vbo, string page) : this(new Action(vbo, page)) { }

    }
}
