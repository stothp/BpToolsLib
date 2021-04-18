using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib.Interpreter
{
    public class DataTypeConverter
    {
        public static BpToolsLib.DataType GetDataTypeByName(string type)
        {
            switch (type)
            {
                case "binary":
                    return BpToolsLib.DataType.Binary;
                case "collection":
                    return BpToolsLib.DataType.Collection;
                case "date":
                    return BpToolsLib.DataType.Date;
                case "datetime": 
                    return BpToolsLib.DataType.Datetime;
                case "flag": 
                    return BpToolsLib.DataType.Flag;
                case "image": 
                    return BpToolsLib.DataType.Image;
                case "number": 
                    return BpToolsLib.DataType.Number;
                case "password": 
                    return BpToolsLib.DataType.Password;
                case "text": 
                    return BpToolsLib.DataType.Text;
                case "time": 
                    return BpToolsLib.DataType.Time;
                case "timespan": 
                    return BpToolsLib.DataType.Timespan;
                case "unknown":
                    return BpToolsLib.DataType.Unknown;
                default:
                    throw new System.Exception("Unknown DataType name: " + type);
            }
        }
    }
}
