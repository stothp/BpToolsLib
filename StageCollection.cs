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
    public class StageCollection: Stage
    {
        public DataType DataType {
            get
            {
                return DataType.Collection;
            }
        }

        public string InitialValue { get; set; } = "";
        public bool HideFromOtherPages { get; set; } = true;
        public bool ResetToInitialValueAtStart { get; set; } = true;
        public bool SingleRow { get; set; } = false;
        public List<CollectionColumn> Columns { get; } = new List<CollectionColumn>();
        public List<CollectionRow> Rows { get; } = new List<CollectionRow>();

        public StageCollection() : base("Collection", StageType.Data)
        {
        }
        
        public StageCollection(string name) : base(name, StageType.Collection) {
            Name = name;
        }
        
        public StageCollection(string name, string initialValue) : this(name)
        {
            InitialValue = initialValue;
        }

        public StageCollection(string name, string initialValue, bool hideFromOtherPages) : this(name, initialValue)
        {
            HideFromOtherPages = hideFromOtherPages;
        }
    }
}
