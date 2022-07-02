using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    internal class UserInteraction
    {
        
        private bool _isAlive = true;
        private TaskHub _taskHub = TaskHub.GetInstance();

        public void Run()
        {
            DisplayStartMessage();
            while (_isAlive)
            {
                GetCallbackOnParsedCommands();
            }
            DisplayEndingMessage();
        }
        private void GetCallbackOnParsedCommands()
        {
            GetInputSetStopIfNull(out string? input);
            if (input is null) return;
            string[] commandArgs = SplitArgs(input);
            GetCallback(commandArgs);            
        }

        private void GetCallback(string[] commandArgs)
        {
            if (commandArgs.Length == 0) return;
            try
            {
                switch (commandArgs[0])
                {
                    case "\\create-task":
                        OnCreatingTask(commandArgs);
                        break;
                    case "\\delete-task":
                        OnDeletingTask(commandArgs);
                        break;
                    case "\\set-task-status":
                        OnSettingTaskStatus(commandArgs);
                        break;
                    case "\\show-completed-tasks":
                        OnShowingCompletedTasks();
                        break;
                    case "\\set-deadline":
                        OnSettingDeadline(commandArgs);
                        break;
                    case "\\show-tasks-for-today":
                        OnShowingTasksForToday();
                        break;
                    case "\\show-all-tasks":
                        OnShowingAllTasks();
                        break;
                    case "\\create-group":
                        OnCreatingGroup(commandArgs);
                        break;
                    case "\\delete-group":
                        OnDeletingGroup(commandArgs);
                        break;
                    case "\\delete-task-from-group":
                        OnDeletingTaskFromGroup(commandArgs);
                        break;
                    case "\\add-task-to-group":
                        OnAddingTaskToGroup(commandArgs);
                        break;
                    case "\\show-groups":
                        OnShowingGroups();
                        break;
                    case "\\add-subtask":
                        OnAddingSubTask(commandArgs);
                        break;
                    case "\\set-subtask-status":
                        OnSettingSubTaskStatus(commandArgs);
                        break;
                    case "\\save":
                        OnSaving(commandArgs);
                        break;
                    case "\\load":
                        OnLoading(commandArgs);
                        break;
                    case "\\help":
                        OnHelp();
                        break;
                    default:
                        throw new Exception("TODO");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void OnCreatingTask(string[] commandArgs)
        {
            string id = commandArgs[1];
            string description = commandArgs[2];
            DateTime deadline = DateTime.Parse(commandArgs[3]);
            _taskHub.AddTask(new Task(new TaskHeader(id, description, false, deadline)));
        }

        private void OnDeletingTask(string[] commandArgs)
        {
            string id = commandArgs[1];
            _taskHub.RemoveTask(id);
        }

        private void OnSettingTaskStatus(string[] commandArgs)
        {
            string id = commandArgs[1];
            bool isCompleted = bool.Parse(commandArgs[2]);
            Task requiredTask = _taskHub.GetTask(id);
            requiredTask.IsCompleted = isCompleted;
        }

        private void OnShowingCompletedTasks()
        {
            GroupOfTasks completedTasks = _taskHub.GetCompletedTasks();
            GroupOfTasksDisplayer.Display(completedTasks);
        }
        private void OnSettingDeadline(string[] commandArgs)
        {
            string id = commandArgs[1];
            DateTime deadline = DateTime.Parse(commandArgs[2]);
            Task requiredTask = _taskHub.GetTask(id);
            requiredTask.Deadline = deadline;
        }
        private void OnShowingTasksForToday()
        {
            GroupOfTasks tasksForToday = _taskHub.GetTasksForToday();
            GroupOfTasksDisplayer.Display(tasksForToday);
        }
        private void OnShowingAllTasks()
        {
            TaskHubDisplayer.Display(_taskHub);
        }
        private void OnCreatingGroup(string[] commandArgs)
        {
            string id = commandArgs[1];
            string name = commandArgs[2];
            _taskHub.AddGroupOfTasks(new GroupOfTasks(new Dictionary<string, Task>(), id, name));
        }
        private void OnDeletingGroup(string[] commandArgs)
        {
            string id = commandArgs[1];
            _taskHub.RemoveGroupOfTasks(id);
        }
        private void OnDeletingTaskFromGroup(string[] commandArgs)
        {
            string groupId = commandArgs[1];
            string taskId = commandArgs[2];
            _taskHub.RemoveTaskFromGroup(groupId, taskId);
        }
        private void OnAddingTaskToGroup(string[] commandArgs)
        {
            string groupId = commandArgs[1];
            string taskId = commandArgs[2];
            _taskHub.AddTaskToGroup(groupId, taskId);
        }

        private void OnShowingGroups()
        {
            foreach (var groupOfTasks in (IEnumerable<GroupOfTasks>)_taskHub)
            {
                GroupOfTasksDisplayer.Display(groupOfTasks);
            }
        }
        private void OnAddingSubTask(string[] commandArgs)
        {
            string taskId = commandArgs[1];
            string subTaskId = commandArgs[2];
            string subtaskDescription = commandArgs[3];
            Task requiredTask = _taskHub.GetTask(taskId);
            SubTask subTask = new SubTask(new SubTaskHeader(subTaskId, subtaskDescription, false));
            requiredTask.AddSubTask(subTask);
        }
        private void OnSettingSubTaskStatus(string[] commandArgs)
        {
            string taskId = commandArgs[1];
            string subTaskId = commandArgs[2];
            bool isCompleted = bool.Parse(commandArgs[3]);
            Task requiredTask = _taskHub.GetTask(taskId);
            SubTask requiredSubTask = requiredTask.GetSubTask(subTaskId);
            requiredSubTask.IsCompleted = isCompleted;
        }
        private void OnLoading(string[] commandArgs)
        {
            string filename = commandArgs[1];
            TaskHubJsonSerializer.Load(ref _taskHub, filename);
        }

        private void OnSaving(string[] commandArgs)
        {
            string filename = commandArgs[1];
            TaskHubJsonSerializer.Save(_taskHub, filename);
        }
        private void OnHelp()
        {
            Console.WriteLine(HelpMessage);
        }
        private void GetInputSetStopIfNull(out string? input)
        {
            input = Console.ReadLine();
            if (input is null)
            {
                _isAlive = false;
            }
        }
        private static string[] SplitArgs(string input)
        {
            return input.Split(" ");
        }


        private static void DisplayStartMessage()
        {
            Console.WriteLine("This is a test task for Kysect Academy - a simple task tracker");
            Console.WriteLine(HelpMessage);
        }

        private static string HelpMessage =>
        "List of commands:\n" +
            "\\create-task\n" +
            "\\delete-task\n" +
            "\\set-task-status\n" +
            "\\show-completed-status\n" +
            "\\set-deadline\n" + 
            "\\show-tasks-for-today\n" +
            "\\show-all-tasks\n" +
            "\\create-group\n" +
            "\\delete-group\n" +
            "\\delete-task-from-group\n" +
            "\\add-task-to-group\n" +
            "\\show-groups\n" +
            "\\add-subtask\n" +
            "\\set-subtask-status\n" +
            "\\save\n" +
            "\\load\n" +
            "\\help\n"
            ;
        private static void DisplayEndingMessage()
        {
            Console.WriteLine("Shutting down...\nPress \"Enter\" to close the program");
            Console.ReadLine();
        }
    }
}
