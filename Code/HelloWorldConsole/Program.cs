using HelloWorldLibrary;
using System;

namespace HelloWorldConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringToPrint = Greeter.FormatGreeting(args);

            Console.WriteLine(stringToPrint);
        }
    }
}
