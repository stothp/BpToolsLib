using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools
{
    public class CollectionRow : Collection<CollectionField>
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
