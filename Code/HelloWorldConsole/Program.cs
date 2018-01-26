using HelloWorldLibrary;
using System;

namespace HelloWorldConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringToPrint = HelloWorldNamer.GetHelloWorld(args);

            Console.WriteLine(stringToPrint);
        }
    }
}
