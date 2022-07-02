using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TestTask
{
    internal static class TaskHubBinSerializer
    {
        public static void Save(TaskHub instance, string filename)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, instance);
            stream.Close();
        }

        public static void Load(ref TaskHub instance, string filename)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            instance = (TaskHub)formatter.Deserialize(stream);
            stream.Close();
        }
    }
}
