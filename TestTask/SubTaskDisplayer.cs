using System.Text;


namespace TestTask
{
    internal class SubTaskDisplayer
    {
        public static void Display(SubTask subTask)
        {
            Console.Write(GetDisplayMessage(subTask));
        }
        private static string GetDisplayMessage(SubTask subTask)
        {
            StringBuilder sb = new StringBuilder();
            MarkCompletion(subTask, ref sb);
            PutId(subTask, ref sb);
            PutDescription(subTask, ref sb);
            return sb.ToString();
        }
        private static void MarkCompletion(SubTask subTask, ref StringBuilder sb)
        {
            if (subTask.IsCompleted)
            {
                sb.Append("[x] ");
            }
            else
            {
                sb.Append("[ ] ");
            }
        }
        private static void PutId(SubTask subTask, ref StringBuilder sb)
            => sb.Append($"{{{subTask.Id}}} ");

        private static void PutDescription(SubTask subTask, ref StringBuilder sb)
            => sb.Append($"{subTask.Description}\n");

    }

}
