using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    [Serializable]
    internal class SubTask : BaseTask
    {
        public SubTask(SubTaskHeader taskHeader) : base(taskHeader) {}

        public SubTask() : this(new SubTaskHeader()) {}
        
    }
}
