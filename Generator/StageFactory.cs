using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using BpToolsLib;
using BpToolsLib.Interpreter;

namespace BpToolsLib.Generator
{
    public class StageFactory
    {
        public static Stage GetObject(BpToolsLib.Stage stage, string subsheetId)
        {
            if (stage is BpToolsLib.StageAction)
            {
                return new StageAction((BpToolsLib.StageAction)stage, subsheetId);
            }
            else if (stage is BpToolsLib.StageAlert)
            {
                return new StageAlert((BpToolsLib.StageAlert)stage, subsheetId);
            }
            else if (stage is BpToolsLib.StageAnchor)
            {
                return new StageAnchor((BpToolsLib.StageAnchor)stage, subsheetId);
            }
            else if (stage is BpToolsLib.StageBlock)
            {
                return new StageBlock((BpToolsLib.StageBlock)stage, subsheetId);
            }
            else if (stage is BpToolsLib.StageCalculation)
            {
                return new StageCalculation((BpToolsLib.StageCalculation)stage, subsheetId);
            }
            else if (stage is BpToolsLib.StageChoice)
            {
                return new StageChoice((BpToolsLib.StageChoice)stage, subsheetId);
            }
            else if (stage is BpToolsLib.StageChoiceEnd)
            {
                return new StageChoiceEnd((BpToolsLib.StageChoiceEnd)stage, subsheetId);
            }
            else if (stage is BpToolsLib.StageCode)
            {
                return new StageCode((BpToolsLib.StageCode)stage, subsheetId);
            }
            else if (stage is BpToolsLib.StageCollection)
            {
                return new StageCollection((BpToolsLib.StageCollection)stage, subsheetId);
            }
            else if (stage is BpToolsLib.StageData)
            {
                return new StageData((BpToolsLib.StageData)stage, subsheetId);
            }
            else if (stage is BpToolsLib.StageDecision)
            {
                return new StageDecision((BpToolsLib.StageDecision)stage, subsheetId);
            }
            else if (stage is BpToolsLib.StageEnd)
            {
                return new StageEnd((BpToolsLib.StageEnd)stage, subsheetId);
            }
            else if (stage is BpToolsLib.StageException)
            {
                return new StageException((BpToolsLib.StageException)stage, subsheetId);
            }
            else if (stage is BpToolsLib.StageLoop)
            {
                return new StageLoop((BpToolsLib.StageLoop)stage, subsheetId);
            }
            else if (stage is BpToolsLib.StageLoopEnd)
            {
                return new StageLoopEnd((BpToolsLib.StageLoopEnd)stage, subsheetId);
            }
            else if (stage is BpToolsLib.StageMultipleCalculation)
            {
                return new StageMultipleCalculation((BpToolsLib.StageMultipleCalculation)stage, subsheetId);
            }
            else if (stage is BpToolsLib.StageNote)
            {
                return new StageNote((BpToolsLib.StageNote)stage, subsheetId);
            }
            else if (stage is BpToolsLib.StagePage)
            {
                return new StagePage((BpToolsLib.StagePage)stage, subsheetId);
            }
            else if (stage is BpToolsLib.StageProcess)
            {
                return new StageProcess((BpToolsLib.StageProcess)stage, subsheetId);
            }
            else if (stage is BpToolsLib.StageRecover)
            {
                return new StageRecover((BpToolsLib.StageRecover)stage, subsheetId);
            }
            else if (stage is BpToolsLib.StageResume)
            {
                return new StageResume((BpToolsLib.StageResume)stage, subsheetId);
            }
            else if (stage is BpToolsLib.StageStart)
            {
                return new StageStart((BpToolsLib.StageStart)stage, subsheetId);
            } 
            else if (stage is BpToolsLib.StagePageInfo)
            {
                return new StagePageInfo((BpToolsLib.StagePageInfo)stage, subsheetId);
            }
            else
            {
                throw new Exception("Unknown object type: " + stage.GetType());
            }
        }
    }
}
