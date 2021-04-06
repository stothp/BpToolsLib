using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools
{
    public class StartParameter : Parameter, IDataNameHolder
    {
        private MutableDataName MutableDataName { get; } = new MutableDataName();
        public string DataName
        {
            get
            {
                return MutableDataName.Value;
            }

            set
            {
                MutableDataName.Value = value;
            }
        }

        public MutableDataNameSet DataNames
        {
            get
            {
                return new MutableDataNameSet() { MutableDataName };
            }
        }

        public StartParameter(DataType type, string name, string narrative, string stageName) : base (type, name, narrative)
        {
            DataName = stageName;
        }

    }
}
