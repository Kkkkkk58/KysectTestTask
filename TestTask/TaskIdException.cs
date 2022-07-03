using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    internal class TaskIdException : ApplicationException
    {
        public static string NoSuchId(string id) => $"Task with Id {{{id}}} does not exist";
        public static string AlreadyExists(string id) => $"Task with Id {{{id}}} already exists";

        public TaskIdException() { }
        public TaskIdException(string message) : base(message) { }  
        public TaskIdException(string message, Exception innerException) : base(message, innerException) { }
    }
}
