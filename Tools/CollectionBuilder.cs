using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BpToolsLib;

namespace BpToolsLib.Tools
{
    public static class CollectionBuilder
    {
        public static StageCollection BuildCollectionFromTabData(string name, string description, string tabData)
        {
            StageCollection coll = new StageCollection()
            {
                Name = name,
                Description = description
            };

            bool first = true;
            string[] headers = null;
            foreach (string row in tabData.Split("\r\n".ToCharArray()))
            {
                if (first)
                {
                    headers = row.Split('\t');
                    foreach (string field in headers)
                    {
                        coll.Columns.Add(new BpToolsLib.CollectionColumn()
                        {
                            Name = field,
                            Type = BpToolsLib.DataType.Text
                        });
                    }
                    first = false;
                }
                else
                {
                    if (row.Trim().Equals(""))
                    {
                        continue;
                    }
                    BpToolsLib.CollectionRow cRow = new BpToolsLib.CollectionRow();
                    string[] fields = row.Split('\t');
                    for (int i = 0; i < headers.Length; i++)
                    {
                        if (fields.Length < i + 1)
                        {
                            break;
                        }
                        cRow.Add(new BpToolsLib.CollectionField()
                        {
                            Name = headers[i],
                            Value = fields[i]
                        });
                    }
                    if (cRow.Count == headers.Length)
                    {
                        coll.Rows.Add(cRow);
                    }
                }
            }

            return coll;
        }
    }
}
