using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib.Interpreter
{
    public class StageData : Stage
    {
        public BpToolsLib.StageData BpStageData 
        { 
            get 
            { 
                return (BpToolsLib.StageData)base.BpStage; 
            } 
        }

        public StageData(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpToolsLib.StageData();
            Initialize();
        }

        public override BpToolsLib.Stage GetStage()
        {
            BpStageData.DataType = DataTypeConverter.GetDataTypeByName(XmlStage.DataType);
            BpStageData.InitialValue = XmlStage.InitialValue.Value;
            BpStageData.HideFromOtherPages = XmlStage.Private != null;
            BpStageData.ResetToInitialValueAtStart = XmlStage.AlwaysInit != null;
            switch (XmlStage.Exposure)
            {
                case "Environment":
                    BpStageData.Exposure = BpToolsLib.StageData.DataExposure.Environment;
                    break;
                case "Session":
                    BpStageData.Exposure = BpToolsLib.StageData.DataExposure.Session;
                    break;
                case "Statistic":
                    BpStageData.Exposure = BpToolsLib.StageData.DataExposure.Statistic;
                    break;
                default:
                    BpStageData.Exposure = BpToolsLib.StageData.DataExposure.None;
                    break;
            }
            return BpStage;
        }

        public void SetNextStages(BpToolsLib.StageSet set)
        {
        }

    }
}
