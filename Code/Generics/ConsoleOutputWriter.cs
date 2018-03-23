using System;

namespace Generics
{
    public class ConsoleOutputWriter : IOutputWriter
    {
        public ConsoleOutputWriter()
        {
            var i = 0;
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}