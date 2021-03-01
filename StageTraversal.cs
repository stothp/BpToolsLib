using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools
{
    public static class StageTraversal
    {
        public static HashSet<Stage> GetTraversedStages(ITraversable start)
        {
            HashSet<Stage> stages = new HashSet<Stage>();
            stages.Add((Stage)start);

            foreach (Stage stage in start.NextStages)
            {
                stages.UnionWith(GetTraversedStages((ITraversable)stage));
            }

            return stages;
        }
    }
}
