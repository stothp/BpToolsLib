using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.Generator
{
    public static class DataTypeConverter
    {
        public static string GetText(BpTools.DataType type)
        {
            switch (type)
            {
                case BpTools.DataType.Binary: 
                    return "binary";
                case BpTools.DataType.Collection:
                    return "collection";
                case BpTools.DataType.Date:
                    return "date";
                case BpTools.DataType.Datetime:
                    return "datetime";
                case BpTools.DataType.Flag:
                    return "flag";
                case BpTools.DataType.Image:
                    return "image";
                case BpTools.DataType.Number:
                    return "number";
                case BpTools.DataType.Password:
                    return "password";
                case BpTools.DataType.Text:
                    return "text";
                case BpTools.DataType.Time:
                    return "time";
                case BpTools.DataType.Timespan:
                    return "timespan";
                case BpTools.DataType.Unknown:
                    return "unknown";
                default:
                    throw new Exception("Unknown DataType provided.");
            }
        }
    }
}
