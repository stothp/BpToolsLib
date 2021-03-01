using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools
{

    public class StageCollection : Collection<Stage>, BpElement
    {
        public HashSet<Stage> GetTraversedStages()
        {
            HashSet<Stage> stages = new HashSet<Stage>();

            foreach (Stage stage in this)
            {
                if (stage is ITraversable)
                {
                    stages.Add(stage);
                }
                else
                {
                    stages.UnionWith(StageTraversal.GetTraversedStages((ITraversable)stage));
                }
            }
            
            return stages;
        }
    }
}
