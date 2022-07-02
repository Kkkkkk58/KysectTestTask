namespace TestTask
{
    [Serializable]
    internal class SubTask : BaseTask
    {
        public SubTask(SubTaskHeader taskHeader) : base(taskHeader) {}

        public SubTask() : this(new SubTaskHeader()) {}
        
    }
}
