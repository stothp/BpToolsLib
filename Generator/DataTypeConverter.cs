using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib.Generator
{
    public static class DataTypeConverter
    {
        public static string GetText(BpToolsLib.DataType type)
        {
            switch (type)
            {
                case BpToolsLib.DataType.Binary: 
                    return "binary";
                case BpToolsLib.DataType.Collection:
                    return "collection";
                case BpToolsLib.DataType.Date:
                    return "date";
                case BpToolsLib.DataType.Datetime:
                    return "datetime";
                case BpToolsLib.DataType.Flag:
                    return "flag";
                case BpToolsLib.DataType.Image:
                    return "image";
                case BpToolsLib.DataType.Number:
                    return "number";
                case BpToolsLib.DataType.Password:
                    return "password";
                case BpToolsLib.DataType.Text:
                    return "text";
                case BpToolsLib.DataType.Time:
                    return "time";
                case BpToolsLib.DataType.Timespan:
                    return "timespan";
                case BpToolsLib.DataType.Unknown:
                    return "unknown";
                default:
                    throw new Exception("Unknown DataType provided.");
            }
        }
    }
}
