using System.Collections;


namespace TestTask
{
    [Serializable]
    internal class TaskHub : IEnumerable<Task>, IEnumerable<GroupOfTasks>
    {
        private static TaskHub? _instance;

        private static object _lock = new();

        public const string UngrouppedName = "UngrouppedIdLJGS";
        private GroupOfTasks _ungrouppedTasks = new(name: UngrouppedName);

        private Dictionary<string, GroupOfTasks> _grouppedTasks = new();

        //public static TaskHub GetInstance(GroupOfTasks ungrouppedTasks, Dictionary<string, GroupOfTasks> grouppedTasks)
        //{
        //    if (_instance is null)
        //    {
        //        lock (_lock)
        //        {
        //            if (_instance is null)
        //            {
        //                _instance = new TaskHub(ungrouppedTasks, grouppedTasks);
        //            }
        //        }
        //    }
        //    return _instance;
        //}

        public static TaskHub GetInstance()
        {
            if (_instance is null)
            {
                lock (_lock)
                {
                    if (_instance is null)
                    {
                        _instance = new TaskHub();
                    }
                }
            }
            return _instance;
        }

        //private TaskHub(GroupOfTasks ungrouppedTasks, Dictionary<string, GroupOfTasks> grouppedTasks)
        //{
        //    _ungrouppedTasks = ungrouppedTasks;
        //    _grouppedTasks = grouppedTasks;
        //}

        private TaskHub() { }

        public void AddTask(Task task)
        {
            if (!_ungrouppedTasks.TryAdd(task.Id, task))
            {
                throw new Exception("TODO");
            }
        }

        public void RemoveTask(string id)
        {
            _ungrouppedTasks.Remove(id);
        }

        public void RemoveTask(Task task)
        {
            _ungrouppedTasks.Remove(task.Id);
        }

        public Task GetTask(string id)
        {
            if (_ungrouppedTasks.TryGetValue(id, out var task))
            {
                return task;
            }
            foreach(var groupOfTasks in _grouppedTasks.Values)
            {
                if (groupOfTasks.TryGetValue(id, out task))
                {
                    return task;
                }
            }
            throw new Exception("TODO");
        }

        public void AddGroupOfTasks(GroupOfTasks groupOfTasks)
        {
            if (!_grouppedTasks.TryAdd(groupOfTasks.Id, groupOfTasks))
            {
                throw new Exception("TODO");
            }
        }

        public void AddTaskToGroup(string groupId, Task task)
        {
            _grouppedTasks[groupId].Add(task);
        }
        public void AddTaskToGroup(string groupId, string taskId)
        {
            Task task = GetTask(taskId);
            _grouppedTasks[groupId].Add(task);
        }
        public void RemoveGroupOfTasks(string id)
        {
            _grouppedTasks.Remove(id);
        }

        public void RemoveGroupOfTasks(GroupOfTasks groupOfTasks)
        {
            _grouppedTasks.Remove(groupOfTasks.Id);
        }
        public void RemoveTaskFromGroup(string groupId, string taskId)
        {
            _grouppedTasks[groupId].Remove(groupId);
        }

        public GroupOfTasks GetGroupOfTasks(string id)
        {
            if (_grouppedTasks.TryGetValue(id, out var groupOfTasks))
            {
                return groupOfTasks;
            }
            throw new Exception("TODO");
        }
        IEnumerator<Task> IEnumerable<Task>.GetEnumerator()
        {
            return _ungrouppedTasks.GetEnumerator();
        }

        IEnumerator<GroupOfTasks> IEnumerable<GroupOfTasks>.GetEnumerator()
        {
            return _grouppedTasks.Values.GetEnumerator();
  
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return ((IEnumerable)_ungrouppedTasks).GetEnumerator();
            foreach (var groupOfTasks in _grouppedTasks.Values)
            {
                yield return ((IEnumerable)groupOfTasks).GetEnumerator();
            }
        }

        public GroupOfTasks GetCompletedTasks()
        {
            GroupOfTasks completedTasks = new(name: "Completed Tasks");

            foreach(Task task in (IEnumerable)this)
            {
                if (task.IsCompleted)
                {
                    completedTasks.Add(task);
                }
            }
            return completedTasks;
        }

        public GroupOfTasks GetTasksForToday()
        {
            GroupOfTasks tasksForToday = new(name: "Tasks for Today");

            foreach(Task task in (IEnumerable)this)
            {
                if (task.Deadline is not null && ((DateTime)task.Deadline).Date == DateTime.Today)
                {
                    tasksForToday.Add(task);
                }
            }
            return tasksForToday;
        }

        public void Reset(GroupOfTasks ungrouppedTasks, Dictionary<string, GroupOfTasks> grouppedTasks)
        {
            _ungrouppedTasks = ungrouppedTasks;
            _grouppedTasks = grouppedTasks;
        }
    }
}
