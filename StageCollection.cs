using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib
{
    public class StageCollection: Stage
    {
        public DataType DataType {
            get
            {
                return DataType.Collection;
            }
        }

        public bool HideFromOtherPages { get; set; } = true;
        public bool ResetToInitialValueAtStart { get; set; } = true;
        public bool SingleRow { get; set; } = false;
        public List<CollectionColumn> Columns { get; } = new List<CollectionColumn>();
        public List<CollectionRow> Rows { get; } = new List<CollectionRow>();

        public StageCollection() : base("Collection", StageType.Collection)
        {
        }
        
        public StageCollection(string name) : base(name, StageType.Collection) {
            Name = name;
        }
        
        public StageCollection(string name, bool hideFromOtherPages) : this(name)
        {
            HideFromOtherPages = hideFromOtherPages;
        }
    }
}
