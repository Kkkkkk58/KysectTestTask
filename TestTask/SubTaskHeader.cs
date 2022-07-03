namespace TestTask
{
    [Serializable]
    internal class SubTaskHeader : BaseTaskHeader
    {
        public SubTaskHeader(string id, string description = "N/D")
            : base(id, description) { }
    }
}
