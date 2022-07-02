using System.Collections;

namespace TestTask
{
    [Serializable]
    internal class Task : BaseTask, IEnumerable<SubTask>
    {
        private Dictionary<string, SubTask> _subtasks;
        public DateTime? Deadline { get; set; }

        public Task(TaskHeader taskHeader, Dictionary<string, SubTask> subtasks) : base(taskHeader)
        {
            Deadline = taskHeader.Deadline;
            _subtasks = subtasks;
        }
        public Task(TaskHeader taskHeader) : this(taskHeader, new Dictionary<string, SubTask>()) { }
        public Task(Dictionary<string, SubTask> subtasks) : this(new TaskHeader(Guid.NewGuid().ToString()), subtasks) { }

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
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_subtasks.Values).GetEnumerator();
        }
    }
}
