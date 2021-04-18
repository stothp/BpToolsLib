using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BpToolsLib
{
    public class StageReference : Stage
    {
        public StageReference() : base()
        {
        }

        public StageReference(string id) : this()
        {
            Id = id;
        }

    }
}
