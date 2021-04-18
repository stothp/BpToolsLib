using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib
{
    public class StageEnd : Stage, ITraversable, IDataNameHolder
    {
        public StageSet NextStages { get { return new StageSet(); } }


        public MutableDataNameSet DataNames
        {
            get
            {
                MutableDataNameSet dataNames = new MutableDataNameSet();
                foreach (EndParameter parameter in OutputParameters)
                {
                    dataNames.UnionWith(parameter.DataNames);
                }
                return dataNames;
            }
        }

        public StageEnd() : base("End", StageType.End) { }
        public Collection<EndParameter> OutputParameters { get; set; } = new Collection<EndParameter>();

    }
}
