using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools
{
    public static class TraverseStages
    {
        public static StageSet GetTraversedStages(ITraversable start)
        {
            StageSet stages = new StageSet();
            stages.Add((Stage)start);

            foreach (Stage stage in start.NextStages)
            {
                stages.UnionWith(GetTraversedStages((ITraversable)stage));
            }

            return stages;
        }
    }
}
