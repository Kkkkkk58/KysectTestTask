namespace TestTask
{
    internal class TaskHubDisplayer
    {
        public static void Display(TaskHub instance)
        {
            DisplaySingleTasks(instance);
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
