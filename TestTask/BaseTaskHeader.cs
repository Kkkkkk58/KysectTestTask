namespace TestTask
{
    [Serializable]
    internal abstract class BaseTaskHeader
    {
        public string Id { get; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public BaseTaskHeader(string id, string description, bool isCompleted)
        {
            Id = id;
            Description = description;
            IsCompleted = isCompleted;
        }
    }
}
