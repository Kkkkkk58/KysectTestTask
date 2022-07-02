namespace TestTask
{
    [Serializable]
    internal class TaskHeader : BaseTaskHeader
    {
        public DateTime? Deadline { get; set; }

        public TaskHeader(string description = "N/D", bool isCompleted = false, DateTime? deadline = null)
            : this(new Guid().ToString(), description, isCompleted, deadline) { }

        public TaskHeader(string id, string description, bool isCompleted, DateTime? deadline) 
            : base(id, description, isCompleted)
        {
            Deadline = deadline;
        }
    }
}
