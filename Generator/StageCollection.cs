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
    public class StageCollection : Stage
    {
        readonly BpToolsLib.StageCollection stage;

        public StageCollection(BpToolsLib.StageCollection stage, string subsheetId) : base(stage, subsheetId)
        {
            this.stage = stage;
        }

        public override XmlClasses.Stage GetBpStage()
        {
            XmlClasses.Stage bpStage = base.GetBpStage();

            bpStage.DataType = "collection";
            bpStage.Private = stage.HideFromOtherPages ? "" : null;
            bpStage.AlwaysInit = stage.ResetToInitialValueAtStart ? "" : null;

            bpStage.CollectionInfo = new XmlClasses.CollectionInfo()
            {
                Singlerow = stage.SingleRow ? "" : null,
                Fields = new List<XmlClasses.Field>()
            };

            Dictionary<string, string> nameType = new Dictionary<string, string>();
            foreach (BpToolsLib.CollectionColumn col in stage.Columns)
            {
                bpStage.CollectionInfo.Fields.Add(
                        new XmlClasses.Field()
                        {
                            Name = col.Name,
                            Type = DataTypeConverter.GetText(col.Type)
                        });
                nameType.Add(col.Name, DataTypeConverter.GetText(col.Type));
            }

            bpStage.InitialValue = new XmlClasses.InitialValue()
            {
                Singlerow = stage.SingleRow ? "" : null,
                Rows = new List<XmlClasses.Row>()
            };

            foreach (BpToolsLib.CollectionRow row in stage.Rows)
            {
                XmlClasses.Row xmlRow = new XmlClasses.Row()
                {
                    Fields = new List<XmlClasses.Field>()
                };


                foreach (BpToolsLib.CollectionField field in row)
                {
                    xmlRow.Fields.Add(
                        new XmlClasses.Field()
                        {
                            Name = field.Name,
                            Type = nameType[field.Name],
                            Value = field.Value
                        }
                    );
                }

                bpStage.InitialValue.Rows.Add(xmlRow);
            }

            return bpStage;
        }
    }
}
