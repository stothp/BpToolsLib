using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using BpToolsLib;
using BpToolsLib.XmlClasses;
using BpToolsLib.Interpreter;

namespace BpToolsLib.Generator
{
    public class StageData: Stage
    {
        readonly BpToolsLib.StageData stage;

        public StageData(BpToolsLib.StageData stage, string subsheetId) : base(stage, subsheetId)
        {
            this.stage = stage;
        }

        public override XmlClasses.Stage GetBpStage()
        {
            XmlClasses.Stage bpStage = base.GetBpStage();

            bpStage.DataType = DataTypeConverter.GetText(stage.DataType);
            bpStage.InitialValue = new XmlClasses.InitialValue();
            bpStage.InitialValue.Value = stage.InitialValue;
            if (stage.HideFromOtherPages)
            {
                bpStage.Private = string.Empty;
            }
            if (stage.ResetToInitialValueAtStart)
            {
                bpStage.AlwaysInit = string.Empty;
            }
            switch (stage.Exposure)
            {
                case BpToolsLib.StageData.DataExposure.Environment:
                    bpStage.Exposure = "Environment";
                    break;
                case BpToolsLib.StageData.DataExposure.Session:
                    bpStage.Exposure = "Session";
                    break;
                case BpToolsLib.StageData.DataExposure.Statistic:
                    bpStage.Exposure = "Statistic";
                    break;
            }

            return bpStage;
        }
    }
}
