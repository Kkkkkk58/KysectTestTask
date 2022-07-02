using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace TestTask
{
    internal static class TaskHubJsonSerializer
    {
        public static async void Save(TaskHub instance, string filename)
        {
            using FileStream createStream = File.Create(filename);
            await JsonSerializer.SerializeAsync(createStream, instance);
            await createStream.DisposeAsync();
        }

        public static void Load(ref TaskHub instance, string filename)
        {
            string parsedJson = File.ReadAllText(filename);
            instance = JsonSerializer.Deserialize<TaskHub>(parsedJson);
        }
    }
}
