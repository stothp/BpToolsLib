﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.Interpreter
{
    public class StageCollection : Stage
    {
        public BpTools.StageCollection BpStageCollection
        {
            get
            {
                return (BpTools.StageCollection)base.BpStage;
            }
        }

        public StageCollection(XmlClasses.Stage xmlStage) : base(xmlStage)
        {
            base.BpStage = new BpTools.StageCollection();
            Initialize();
        }

        public override BpTools.Stage GetStage()
        {
            BpStageCollection.HideFromOtherPages = XmlStage.Private != null;
            BpStageCollection.ResetToInitialValueAtStart = XmlStage.AlwaysInit != null;

            if (XmlStage.CollectionInfo != null)
            {
                BpStageCollection.SingleRow = XmlStage.CollectionInfo.Singlerow != null;
            } else
            {
                BpStageCollection.SingleRow = false;
            }
            foreach (XmlClasses.Field field in XmlStage.CollectionInfo.Fields)
            {
                BpStageCollection.Columns.Add(
                    new BpTools.CollectionColumn()
                    {
                        Name = field.Name,
                        Type = DataTypeConverter.GetDataTypeByName(field.Type),
                        Description = field.Description,
                        Namespace = field.Namespace
                    }
                );
            }
            foreach (XmlClasses.Row row in XmlStage.InitialValue.Rows)
            {
                foreach (XmlClasses.Field field in row.Fields)
                {
                    BpStageCollection.Rows.Add(
                        new BpTools.CollectionRow()
                        {
                            Name = field.Name,
                            Value = field.Value
                        }
                    );
                }
            }

            return BpStage;
        }

        public void SetNextStages(BpTools.StageSet set)
        {
        }

    }
}
