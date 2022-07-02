﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    [Serializable]
    internal class SubTaskHeader : BaseTaskHeader
    {
        public SubTaskHeader(string description = "N/D", bool isCompleted = false) 
            : this(new Guid().ToString(), description, isCompleted) { }

        public SubTaskHeader(string id, string description, bool isCompleted)
            : base(id, description, isCompleted) { }
    }
}