using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    internal class TaskHubDisplayer
    {
        public static void Display(TaskHub instance)
        {
            DisplayGroups(instance);
            DisplaySingleTasks(instance);
        }
        private static void DisplayGroups(TaskHub instance)
        {
            foreach(GroupOfTasks groupOfTasks in (IEnumerable<GroupOfTasks>)instance)
            {
                GroupOfTasksDisplayer.Display(groupOfTasks);
            }
        }

        private static void DisplaySingleTasks(TaskHub instance)
        {
            foreach(Task task in (IEnumerable<Task>)instance)
            {
                TaskDisplayer.Display(task);    
            }
        }

    }
}
