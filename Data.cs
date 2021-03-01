using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpTools
{
    public class Data : Stage, IDataHolder
    {
        public DataType _dataType;
        public DataType DataType {
            get
            {
                return _dataType;
            }
            set
            {
                if (value == DataType.Collection)
                {
                    throw new Exception("The DataType property cannot be set to Collection!");
                }
                _dataType = value;
            }
        }
        public string InitialValue { get; set; } = "";
        public bool HideFromOtherPages { get; set; } = true;
        public bool ResetToInitialValueAtStart { get; set; } = true;

        public Data(string name, DataType dataType) : base(name, StageType.Data) {
            Name = name;
            DataType = dataType;
        }
        public Data(string name, DataType dataType, string initialValue) : this(name, dataType)
        {
            InitialValue = initialValue;    
        }
        public Data(string name, DataType dataType, string initialValue, bool hideFromOtherPages) : this(name, dataType, initialValue)
        {
            HideFromOtherPages = hideFromOtherPages;
        }
    }
}
