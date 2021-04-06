using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.Generator
{
    public static class StageTypeConverter
    {
        public static string GetText(BpTools.Stage.StageType type)
        {
            switch (type)
            {
                case BpTools.Stage.StageType.Action: 
                    return "Action";
                case BpTools.Stage.StageType.Alert:
                    return "Alert";
                case BpTools.Stage.StageType.Anchor:
                    return "Anchor";
                case BpTools.Stage.StageType.Block:
                    return "Block";
                case BpTools.Stage.StageType.Calculation:
                    return "Calculation";
                case BpTools.Stage.StageType.ChoiceStart:
                    return "ChoiceStart";
                case BpTools.Stage.StageType.ChoiceEnd:
                    return "ChoiceEnd";
                case BpTools.Stage.StageType.Code:
                    return "Code";
                case BpTools.Stage.StageType.Collection:
                    return "Collection";
                case BpTools.Stage.StageType.Data:
                    return "Data";
                case BpTools.Stage.StageType.Decision:
                    return "Decision";
                case BpTools.Stage.StageType.End:
                    return "End";
                case BpTools.Stage.StageType.Exception:
                    return "Exception";
                case BpTools.Stage.StageType.LoopEnd:
                    return "LoopEnd";
                case BpTools.Stage.StageType.LoopStart:
                    return "LoopStart";
                case BpTools.Stage.StageType.MultipleCalculation:
                    return "MultipleCalculation";
                case BpTools.Stage.StageType.Note:
                    return "Note";
                case BpTools.Stage.StageType.Process:
                    return "Process";
                case BpTools.Stage.StageType.ProcessInfo:
                    return "ProcessInfo";
                case BpTools.Stage.StageType.Recover:
                    return "Recover";
                case BpTools.Stage.StageType.Resume:
                    return "Resume";
                case BpTools.Stage.StageType.Start:
                    return "Start";
                case BpTools.Stage.StageType.SubSheet:
                    return "SubSheet";
                case BpTools.Stage.StageType.SubsheetInfo:
                    return "SubSheetInfo";
                default:
                    throw new Exception("Unknown StageType provided.");
            }
        }
    }
}
