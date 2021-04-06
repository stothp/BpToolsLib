using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools.Interpreter
{
    public class DataTypeConverter
    {
        public static BpTools.DataType GetDataTypeByName(string type)
        {
            switch (type)
            {
                case "binary":
                    return BpTools.DataType.Binary;
                case "collection":
                    return BpTools.DataType.Collection;
                case "date":
                    return BpTools.DataType.Date;
                case "datetime": 
                    return BpTools.DataType.Datetime;
                case "flag": 
                    return BpTools.DataType.Flag;
                case "image": 
                    return BpTools.DataType.Image;
                case "number": 
                    return BpTools.DataType.Number;
                case "password": 
                    return BpTools.DataType.Password;
                case "text": 
                    return BpTools.DataType.Text;
                case "time": 
                    return BpTools.DataType.Time;
                case "timespan": 
                    return BpTools.DataType.Timespan;
                case "unknown":
                    return BpTools.DataType.Unknown;
                default:
                    throw new System.Exception("Unknown DataType name: " + type);
            }
        }
    }
}
