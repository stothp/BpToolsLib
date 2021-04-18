using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib.Generator
{
    public static class StageTypeConverter
    {
        public static string GetText(BpToolsLib.Stage.StageType type)
        {
            switch (type)
            {
                case BpToolsLib.Stage.StageType.Action: 
                    return "Action";
                case BpToolsLib.Stage.StageType.Alert:
                    return "Alert";
                case BpToolsLib.Stage.StageType.Anchor:
                    return "Anchor";
                case BpToolsLib.Stage.StageType.Block:
                    return "Block";
                case BpToolsLib.Stage.StageType.Calculation:
                    return "Calculation";
                case BpToolsLib.Stage.StageType.ChoiceStart:
                    return "ChoiceStart";
                case BpToolsLib.Stage.StageType.ChoiceEnd:
                    return "ChoiceEnd";
                case BpToolsLib.Stage.StageType.Code:
                    return "Code";
                case BpToolsLib.Stage.StageType.Collection:
                    return "Collection";
                case BpToolsLib.Stage.StageType.Data:
                    return "Data";
                case BpToolsLib.Stage.StageType.Decision:
                    return "Decision";
                case BpToolsLib.Stage.StageType.End:
                    return "End";
                case BpToolsLib.Stage.StageType.Exception:
                    return "Exception";
                case BpToolsLib.Stage.StageType.LoopEnd:
                    return "LoopEnd";
                case BpToolsLib.Stage.StageType.LoopStart:
                    return "LoopStart";
                case BpToolsLib.Stage.StageType.MultipleCalculation:
                    return "MultipleCalculation";
                case BpToolsLib.Stage.StageType.Note:
                    return "Note";
                case BpToolsLib.Stage.StageType.Process:
                    return "Process";
                case BpToolsLib.Stage.StageType.ProcessInfo:
                    return "ProcessInfo";
                case BpToolsLib.Stage.StageType.Recover:
                    return "Recover";
                case BpToolsLib.Stage.StageType.Resume:
                    return "Resume";
                case BpToolsLib.Stage.StageType.Start:
                    return "Start";
                case BpToolsLib.Stage.StageType.SubSheet:
                    return "SubSheet";
                case BpToolsLib.Stage.StageType.SubsheetInfo:
                    return "SubSheetInfo";
                default:
                    throw new Exception("Unknown StageType provided.");
            }
        }
    }
}
