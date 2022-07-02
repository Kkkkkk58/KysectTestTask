using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    internal class GroupOfTasksDisplayer
    {
        public static void Display(GroupOfTasks groupOfTasks)
        {
            Console.WriteLine(GetDisplayMessage(groupOfTasks));
            DisplayTasks(groupOfTasks);
        }
        private static string GetDisplayMessage(GroupOfTasks groupOfTasks)
        {
            StringBuilder sb = new StringBuilder();
            PutId(groupOfTasks, ref sb);
            PutName(groupOfTasks, ref sb);
            return sb.ToString();
        }
        private static void DisplayTasks(GroupOfTasks groupOfTasks)
        {
            foreach (Task task in groupOfTasks)
            {
                TaskDisplayer.Display(task);
            }
        }

        private static void PutId(GroupOfTasks groupOfTasks, ref StringBuilder sb)
            => sb.Append($"Group {{{groupOfTasks.Id}}} ");

        private static void PutName(GroupOfTasks groupOfTasks, ref StringBuilder sb) 
            => sb.Append($"{groupOfTasks.Name}\n");

    }
}
