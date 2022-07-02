using System.Text;

namespace TestTask
{
    internal class TaskDisplayer
    {
        public static void Display(Task task)
        {
            Console.WriteLine(GetDisplayMessage(task));
            DisplaySubTasks(task);
        }
        private static string GetDisplayMessage(Task task)
        {
            StringBuilder sb = new StringBuilder();
            MarkCompletion(task, ref sb);
            PutDeadlineIfAny(task, ref sb);
            PutId(task, ref sb);
            PutDescription(task, ref sb);
            return sb.ToString();
        }

        private static void DisplaySubTasks(Task task)
        {
            foreach (SubTask subTask in task)
            {
                Console.Write("  - ");
                SubTaskDisplayer.Display(subTask);
            }
        }

        private static void PutDeadlineIfAny(Task task, ref StringBuilder sb)
        {
            if (task.Deadline is not null)
            {
                sb.Append($" ({task.Deadline.ToString()}) ");
            }
        }
        private static void MarkCompletion(Task task, ref StringBuilder sb)
        {
            if (task.IsCompleted)
            {
                sb.Append("[x] ");
            }
            else
            {
                sb.Append("[ ] ");
            }
        }
        private static void PutId(Task task, ref StringBuilder sb) => sb.Append($"{{{task.Id}}} ");

        private static void PutDescription(Task task, ref StringBuilder sb) => sb.Append($"{task.Description}\n");

    }
}
