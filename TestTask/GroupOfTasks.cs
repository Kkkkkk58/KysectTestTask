using System.Diagnostics.CodeAnalysis;

namespace TestTask
{
    [Serializable]
    internal class GroupOfTasks
    {
        private readonly Dictionary<string, Task> _tasks;
        public string Id { get; }
        public string Name { get; set; }


        public GroupOfTasks(Dictionary<string, Task> tasks, string id, string name)
        {
            _tasks = tasks;
            Id = id;
            Name = name;
        }

        public GroupOfTasks(string name = "N/D")
            : this(new Dictionary<string, Task>(), Guid.NewGuid().ToString(), name) { }

        public Task this[string key]
        {
            get => _tasks[key];
            set => _tasks[key] = value;
        }

        public bool TryGetValue(string id, [MaybeNullWhen(false)] out Task task)
        {
            return _tasks.TryGetValue(id, out task);
        }

        public void Add(Task task)
        {
            _tasks.Add(task.Id, task);
        }

        public bool TryAdd(Task task)
        {
            return _tasks.TryAdd(task.Id, task);
        }

        public bool Remove(string id)
        {
            return _tasks.Remove(id);
        }

        public bool Contains(string id)
        {
            return _tasks.ContainsKey(id);
        }

        public IEnumerator<Task> GetEnumerator()
        {
            return _tasks.Values.GetEnumerator();
        }
    }
}
