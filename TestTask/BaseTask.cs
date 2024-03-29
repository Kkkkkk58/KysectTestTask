﻿namespace TestTask
{
    [Serializable]
    internal class BaseTask
    {
        private readonly BaseTaskHeader _taskHeader;

        public string Id
        {
            get { return _taskHeader.Id; }
        }

        public string Description
        {
            get { return _taskHeader.Description; }
            set { _taskHeader.Description = value; }
        }

        public bool IsCompleted
        {
            get { return _taskHeader.IsCompleted; }
            set { _taskHeader.IsCompleted = value; }
        }

        public BaseTask(BaseTaskHeader baseTaskHeader)
        {
            _taskHeader = baseTaskHeader;
        }
    }
}
