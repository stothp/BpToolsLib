using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib
{
    public static class TraverseStages
    {
        public static StageSet GetTraversedStages(ITraversable start)
        {
            StageSet stages = new StageSet();
            stages.Add((Stage)start);

            foreach (Stage stage in start.NextStages)
            {
                if (!stages.Contains(stage))
                {
                    stages.UnionWith(GetTraversedStages((ITraversable)stage));
                }
            }

            return stages;
        }
    }
}
