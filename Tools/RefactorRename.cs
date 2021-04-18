using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BpToolsLib.Tools
{
    public static class RefactorRename
    {

        private static void RenameDataReferences(StageSet stageSet, string originalName, string newName)
        {
            foreach (Stage bpStage in stageSet)
            {
                if (bpStage is IExpressionHolder)
                {
                    foreach (MutableExpression expression in ((IExpressionHolder)bpStage).Expressions)
                    {
                        expression.Value = expression.Value.Replace("[" + originalName + "]", "[" + newName + "]");
                    }
                }
                if (bpStage is IDataNameHolder)
                {
                    foreach (MutableDataName dataName in ((IDataNameHolder)bpStage).DataNames)
                    {
                        if (dataName.Value.Equals(originalName))
                        {
                            dataName.Value = newName;
                        }
                    }
                }
            }
        }

        private static void RenameCollectionReferences(StageSet stageSet, string originalName, string newName)
        {
            foreach (Stage bpStage in stageSet)
            {
                if (bpStage is IExpressionHolder)
                {
                    foreach (MutableExpression expression in ((IExpressionHolder)bpStage).Expressions)
                    {
                         expression.Value = expression.Value.Replace("[" + originalName + ".", "[" + newName + ".");
                    }
                }
                if (bpStage is IDataNameHolder)
                {
                    foreach (MutableDataName dataName in ((IDataNameHolder)bpStage).DataNames)
                    {
                        if (dataName.Value.StartsWith(originalName + "."))
                        {
                            dataName.Value = Regex.Replace(dataName.Value, "^" + originalName + ".", newName + ".");
                        }
                    }
                }
            }
        }

        public static void Rename(Stage stage, StageSet stageSet, string newName)
        {            
            string originalName = stage.Name;
            stage.Name = newName;

            if (stage is StageData)
            {
                RenameDataReferences(stageSet, originalName, newName);
            }
            if (stage is StageCollection)
            {
                RenameDataReferences(stageSet, originalName, newName);
                RenameCollectionReferences(stageSet, originalName, newName);
            }
        }

    }
}
