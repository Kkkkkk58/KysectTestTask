using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    [Serializable]
    internal class GroupOfTasks : IEnumerable<Task>, IDictionary<string, Task>
    {
        private Dictionary<string, Task> _tasks;
        public string Id { get; }
        public string Name { get; set; }

        public ICollection<string> Keys => ((IDictionary<string, Task>)_tasks).Keys;

        public ICollection<Task> Values => ((IDictionary<string, Task>)_tasks).Values;

        public int Count => ((ICollection<KeyValuePair<string, Task>>)_tasks).Count;

        public bool IsReadOnly => ((ICollection<KeyValuePair<string, Task>>)_tasks).IsReadOnly;

        public Task this[string key]
        {
            get => ((IDictionary<string, Task>)_tasks)[key];
            set => ((IDictionary<string, Task>)_tasks)[key] = value;
        }

        public GroupOfTasks(Dictionary<string, Task> tasks, string id, string name)
        {
            _tasks = tasks;
            Id = id;
            Name = name;
        }

        public GroupOfTasks(Dictionary<string, Task> tasks, string name = "N/D")
            : this(tasks, Guid.NewGuid().ToString(), name) { }

        public GroupOfTasks(string name = "N/D")
            : this(new Dictionary<string, Task>(), Guid.NewGuid().ToString(), name) { }

        public IEnumerator<Task> GetEnumerator()
        {
            return _tasks.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_tasks.Values).GetEnumerator();
        }

        public void Add(string id, Task task)
        {
            ((IDictionary<string, Task>)_tasks).Add(id, task);
        }

        public void Add(Task task)
        {
            Add(task.Id, task);
        }

        public bool ContainsKey(string id)
        {
            return ((IDictionary<string, Task>)_tasks).ContainsKey(id);
        }

        public bool Remove(string id)
        {
            return ((IDictionary<string, Task>)_tasks).Remove(id);
        }

        public bool TryGetValue(string id, [MaybeNullWhen(false)] out Task task)
        {
            return ((IDictionary<string, Task>)_tasks).TryGetValue(id, out task);
        }

        public void Add(KeyValuePair<string, Task> item)
        {
            ((ICollection<KeyValuePair<string, Task>>)_tasks).Add(item);
        }

        public void Clear()
        {
            ((ICollection<KeyValuePair<string, Task>>)_tasks).Clear();
        }

        public bool Contains(KeyValuePair<string, Task> item)
        {
            return ((ICollection<KeyValuePair<string, Task>>)_tasks).Contains(item);
        }

        public void CopyTo(KeyValuePair<string, Task>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<string, Task>>)_tasks).CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<string, Task> item)
        {
            return ((ICollection<KeyValuePair<string, Task>>)_tasks).Remove(item);
        }

        IEnumerator<KeyValuePair<string, Task>> IEnumerable<KeyValuePair<string, Task>>.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<string, Task>>)_tasks).GetEnumerator();
        }

        public static explicit operator GroupOfTasks(Dictionary<string, GroupOfTasks>.ValueCollection v)
        {
            throw new NotImplementedException();
        }
    }
}
