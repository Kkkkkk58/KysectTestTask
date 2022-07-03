using System.Collections;


namespace TestTask
{
    [Serializable]
    internal class TaskHub : IEnumerable<Task>, IEnumerable<GroupOfTasks>
    {
        private static TaskHub? _instance;

        private static readonly object _lock = new();

        private readonly GroupOfTasks _allTasks = new(name: "UngrouppedIdLJGS");

        private readonly Dictionary<string, GroupOfTasks> _grouppedTasks = new();


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


        private TaskHub() { }

        public void AddTask(Task task)
        {
            if (!_allTasks.TryAdd(task))
            {
                throw new TaskIdException(TaskIdException.AlreadyExists(task.Id));
            }
        }

        public void RemoveTask(string id)
        {
            if (_allTasks.Contains(id))
            {
                _allTasks.Remove(id);
                foreach (var groupOfTasks in (IEnumerable<GroupOfTasks>)this)
                {
                    if (groupOfTasks.Contains(id))
                    {
                        groupOfTasks.Remove(id);
                    }
                }
            }
            else
            {
                throw new TaskIdException(TaskIdException.NoSuchId(id));
            }
        }

        public Task GetTask(string id)
        {
            if (_allTasks.TryGetValue(id, out var task))
            {
                return task;
            }
            throw new TaskIdException(TaskIdException.NoSuchId(id));
        }

        public void AddGroupOfTasks(GroupOfTasks groupOfTasks)
        {
            if (!_grouppedTasks.TryAdd(groupOfTasks.Id, groupOfTasks))
            {
                throw new GroupIdException(GroupIdException.AlreadyExists(groupOfTasks.Id));
            }
        }

        public void AddTaskToGroup(string groupId, string taskId)
        {
            Task task = GetTask(taskId);
            if (!_grouppedTasks[groupId].TryAdd(task))
            {
                throw new TaskIdException(TaskIdException.AlreadyExists(taskId));
            }
            
        }
        public void RemoveGroupOfTasks(string id)
        {
            if (_grouppedTasks.ContainsKey(id))
            {
                _grouppedTasks.Remove(id);
            }
            else
            {
                throw new GroupIdException(GroupIdException.NoSuchId(id));
            }
        }

        public void RemoveTaskFromGroup(string groupId, string taskId)
        {
            if (_grouppedTasks.ContainsKey(groupId))
            {
                if (_grouppedTasks[groupId].Contains(taskId))
                {
                    _grouppedTasks[groupId].Remove(taskId);
                }
                else
                {
                    throw new TaskIdException(TaskIdException.NoSuchId(taskId));
                }
            }
            else
            {
                throw new GroupIdException(GroupIdException.NoSuchId(groupId));
            }
        }

        IEnumerator<Task> IEnumerable<Task>.GetEnumerator()
        {
            return _allTasks.GetEnumerator();
        }

        IEnumerator<GroupOfTasks> IEnumerable<GroupOfTasks>.GetEnumerator()
        {
            return _grouppedTasks.Values.GetEnumerator();
  
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return ((IEnumerable<Task>)_allTasks).GetEnumerator();
        }

        public GroupOfTasks GetCompletedTasks()
        {
            GroupOfTasks completedTasks = new(name: "Completed Tasks");

            foreach(Task task in (IEnumerable<Task>)this)
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

            foreach(Task task in (IEnumerable<Task>)this)
            {
                if (task.Deadline is not null && ((DateTime)task.Deadline).Date == DateTime.Today)
                {
                    tasksForToday.Add(task);
                }
            }
            return tasksForToday;
        }
    }
}
