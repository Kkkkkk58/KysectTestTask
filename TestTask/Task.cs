namespace TestTask
{
    [Serializable]
    internal class Task : BaseTask
    {
        private readonly Dictionary<string, SubTask> _subtasks;
        public DateTime? Deadline { get; set; }

        public Task(TaskHeader taskHeader, Dictionary<string, SubTask> subtasks)
            : base(taskHeader)
        {
            Deadline = taskHeader.Deadline;
            _subtasks = subtasks;
        }

        public Task(TaskHeader taskHeader)
            : this(taskHeader, new Dictionary<string, SubTask>()) { }


        public SubTask GetSubTask(string subTaskId)
        {
            return _subtasks[subTaskId];
        }

        public void AddSubTask(SubTask subTask)
        {
            _subtasks.Add(subTask.Id, subTask);
        }

        public IEnumerator<SubTask> GetEnumerator()
        {
            return _subtasks.Values.GetEnumerator();
        }
    }
}
