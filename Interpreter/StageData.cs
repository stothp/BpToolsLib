using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.Interpreter
{
    public class StageData : Stage
    {
        public BpTools.StageData BpStageData 
        { 
            get 
            { 
                return (BpTools.StageData)base.BpStage; 
            } 
        }

        public StageData(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpTools.StageData();
            Initialize();
        }

        public override BpTools.Stage GetStage()
        {
            BpStageData.DataType = DataTypeConverter.GetDataTypeByName(XmlStage.DataType);
            BpStageData.InitialValue = XmlStage.InitialValue.Value;
            BpStageData.HideFromOtherPages = XmlStage.Private != null;
            BpStageData.ResetToInitialValueAtStart = XmlStage.AlwaysInit != null;
            switch (XmlStage.Exposure)
            {
                case "Environment":
                    BpStageData.Exposure = BpTools.StageData.DataExposure.Environment;
                    break;
                case "Session":
                    BpStageData.Exposure = BpTools.StageData.DataExposure.Session;
                    break;
                case "Statistic":
                    BpStageData.Exposure = BpTools.StageData.DataExposure.Statistic;
                    break;
                default:
                    BpStageData.Exposure = BpTools.StageData.DataExposure.None;
                    break;
            }
            return BpStage;
        }

        public void SetNextStages(BpTools.StageSet set)
        {
        }

    }
}
