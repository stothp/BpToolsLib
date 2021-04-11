using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using BpTools;
using BpTools.Interpreter;

namespace BpTools.Generator
{
    public class StageFactory
    {
        public static Stage GetObject(BpTools.Stage stage, string subsheetId)
        {
            if (stage is BpTools.StageAction)
            {
                return new StageAction((BpTools.StageAction)stage, subsheetId);
            }
            else if (stage is BpTools.StageAlert)
            {
                return new StageAlert((BpTools.StageAlert)stage, subsheetId);
            }
            else if (stage is BpTools.StageAnchor)
            {
                return new StageAnchor((BpTools.StageAnchor)stage, subsheetId);
            }
            else if (stage is BpTools.StageBlock)
            {
                return new StageBlock((BpTools.StageBlock)stage, subsheetId);
            }
            else if (stage is BpTools.StageCalculation)
            {
                return new StageCalculation((BpTools.StageCalculation)stage, subsheetId);
            }
            else if (stage is BpTools.StageChoice)
            {
                return new StageChoice((BpTools.StageChoice)stage, subsheetId);
            }
            else if (stage is BpTools.StageChoiceEnd)
            {
                return new StageChoiceEnd((BpTools.StageChoiceEnd)stage, subsheetId);
            }
            else if (stage is BpTools.StageCode)
            {
                return new StageCode((BpTools.StageCode)stage, subsheetId);
            }
            else if (stage is BpTools.StageCollection)
            {
                return new StageCollection((BpTools.StageCollection)stage, subsheetId);
            }
            else if (stage is BpTools.StageData)
            {
                return new StageData((BpTools.StageData)stage, subsheetId);
            }
            else if (stage is BpTools.StageDecision)
            {
                return new StageDecision((BpTools.StageDecision)stage, subsheetId);
            }
            else if (stage is BpTools.StageEnd)
            {
                return new StageEnd((BpTools.StageEnd)stage, subsheetId);
            }
            else if (stage is BpTools.StageException)
            {
                return new StageException((BpTools.StageException)stage, subsheetId);
            }
            else if (stage is BpTools.StageLoop)
            {
                return new StageLoop((BpTools.StageLoop)stage, subsheetId);
            }
            else if (stage is BpTools.StageLoopEnd)
            {
                return new StageLoopEnd((BpTools.StageLoopEnd)stage, subsheetId);
            }
            else if (stage is BpTools.StageMultipleCalculation)
            {
                return new StageMultipleCalculation((BpTools.StageMultipleCalculation)stage, subsheetId);
            }
            else if (stage is BpTools.StageNote)
            {
                return new StageNote((BpTools.StageNote)stage, subsheetId);
            }
            else if (stage is BpTools.StagePage)
            {
                return new StagePage((BpTools.StagePage)stage, subsheetId);
            }
            else if (stage is BpTools.StageProcess)
            {
                return new StageProcess((BpTools.StageProcess)stage, subsheetId);
            }
            else if (stage is BpTools.StageRecover)
            {
                return new StageRecover((BpTools.StageRecover)stage, subsheetId);
            }
            else if (stage is BpTools.StageResume)
            {
                return new StageResume((BpTools.StageResume)stage, subsheetId);
            }
            else if (stage is BpTools.StageStart)
            {
                return new StageStart((BpTools.StageStart)stage, subsheetId);
            } 
            else if (stage is BpTools.StagePageInfo)
            {
                return new StagePageInfo((BpTools.StagePageInfo)stage, subsheetId);
            }
            else
            {
                throw new Exception("Unknown object type: " + stage.GetType());
            }
        }
    }
}
