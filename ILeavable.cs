﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpTools
{
    public interface ILeavable : ITraversable
    {
        Stage NextStage { get; set; }
    }
}
