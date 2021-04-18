using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib.Interpreter
{
    public class StageFactory
    {
        private XmlClasses.Stage XmlStage { get; set; }

        public StageFactory(XmlClasses.Stage xmlStage)
        {
            this.XmlStage = xmlStage;
        }

        public Stage GetStage()
        {
            Stage stage;

            switch (XmlStage.Type)
            {
                case "Action":
                    stage = new StageAction(XmlStage);
                    break;
                case "Alert":
                    stage = new StageAlert(XmlStage);
                    break;
                case "Anchor":
                    stage = new StageAnchor(XmlStage);
                    break;
                case "Block":
                    stage = new StageBlock(XmlStage);
                    break;
                case "Calculation":
                    stage = new StageCalculation(XmlStage);
                    break;
                case "ChoiceStart":
                    stage = new StageChoice(XmlStage);
                    break;
                case "ChoiceEnd":
                    stage = new StageChoiceEnd(XmlStage);
                    break;
                case "Code":
                    stage = new StageCode(XmlStage);
                    break;
                case "Collection":
                    stage = new StageCollection(XmlStage);
                    break;
                case "Data":
                    stage = new StageData(XmlStage);
                    break;
                case "Decision":
                    stage = new StageDecision(XmlStage);
                    break;
                case "End":
                    stage = new StageEnd(XmlStage);
                    break;
                case "Exception":
                    stage = new StageException(XmlStage);
                    break;
                case "LoopStart":
                    stage = new StageLoop(XmlStage);
                    break;
                case "LoopEnd":
                    stage = new StageLoopEnd(XmlStage);
                    break;
                case "MultipleCalculation":
                    stage = new StageMultipleCalculation(XmlStage);
                    break;
                case "Note":
                    stage = new StageNote(XmlStage);
                    break;
                case "Process":
                    stage = new StageProcess(XmlStage);
                    break;
                case "Recover":
                    stage = new StageRecover(XmlStage);
                    break;
                case "Resume":
                    stage = new StageResume(XmlStage);
                    break;
                case "SubSheet":
                    stage = new StagePage(XmlStage);
                    break;
                case "SubSheetInfo":
                    stage = new StagePageInfo(XmlStage);
                    break;
                case "Start":
                    stage = new StageStart(XmlStage);
                    break;
                default:
                    throw new Exception("Invalid stage type: " + XmlStage.Type);
            }

            return stage;
        }
    }
}
