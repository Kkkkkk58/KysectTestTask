namespace TestTask
{
    [Serializable]
    internal class TaskHeader : BaseTaskHeader
    {
        public DateTime? Deadline { get; set; } = null;

        public TaskHeader(string id, string description = "N/D") 
            : base(id, description) { }
    }
}
