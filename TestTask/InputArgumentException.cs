using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    internal class InputArgumentsException : ArgumentException
    {
        public InputArgumentsException() { }
        public InputArgumentsException(string methodName, int expectedArgs, int receivedArgs)
            : base($"Method {methodName} expected {expectedArgs} arguments but received {receivedArgs}\n" +
                  $"Check the input format by calling \\help") { }
        public InputArgumentsException(string methodName, int expectedArgs, int receivedArgs, Exception innerException)
            : base($"Method {methodName} expected {expectedArgs} arguments but received {receivedArgs}\n" +
                  $"Check the input format by calling \\help", innerException) { }
    }
}
