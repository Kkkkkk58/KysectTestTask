using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    internal class GroupIdException : ApplicationException
    {
        public static string NoSuchId(string id) => $"Group with Id {{{id}}} does not exist";
        public static string AlreadyExists(string id) => $"Group with Id {{{id}}} already exist";

        public GroupIdException() { }
        public GroupIdException(string message) : base(message) { }
        public GroupIdException(string message, Exception innerException) : base(message, innerException) { }

    }
}
