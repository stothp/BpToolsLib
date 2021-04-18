using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BpToolsLib.Tools
{
    public static class DeleteUnused
    {

        private static Boolean HasDataReference(StageSet stageSet, Stage stage)
        {
            foreach (Stage bpStage in stageSet)
            {
                if (bpStage is IExpressionHolder)
                {
                    foreach (MutableExpression expression in ((IExpressionHolder)bpStage).Expressions)
                    {
                        if (expression.Value.Contains("[" + stage.Name + "]"))
                        {
                            return true;
                        }
                    }
                }
                if (bpStage is IDataNameHolder)
                {
                    foreach (MutableDataName dataName in ((IDataNameHolder)bpStage).DataNames)
                    {
                        if (dataName.Value.Equals(stage.Name))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private static bool HasCollectionReference(StageSet stageSet, Stage stage)
        {
            foreach (Stage bpStage in stageSet)
            {
                if (bpStage is IExpressionHolder)
                {
                    foreach (MutableExpression expression in ((IExpressionHolder)bpStage).Expressions)
                    {
                        if (expression.Value.Contains("[" + stage.Name + "."))
                        {
                            return true;
                        }
                    }
                }
                if (bpStage is IDataNameHolder)
                {
                    foreach (MutableDataName dataName in ((IDataNameHolder)bpStage).DataNames)
                    {
                        if (dataName.Value.StartsWith(stage.Name + "."))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static StageSet DeleteUnusedDataAndCollection(StageSet stageSet)
        {
            StageSet newStageSet = new StageSet(stageSet);
            foreach (Stage stage in stageSet)
            {
                if (stage is StageData || stage is StageCollection)
                {
                    if (!HasDataReference(newStageSet, stage))
                    {
                        newStageSet.Remove(stage);
                        continue;
                    }
                }
                if (stage is StageCollection)
                {
                    if (!HasCollectionReference(newStageSet, stage))
                    {
                        newStageSet.Remove(stage);
                        continue;
                    }
                }
            }
            return newStageSet;
        }

    }
}
