namespace TestTask
{
    [Serializable]
    internal abstract class BaseTaskHeader
    {
        public string Id { get; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; } = false;

        public BaseTaskHeader(string id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
