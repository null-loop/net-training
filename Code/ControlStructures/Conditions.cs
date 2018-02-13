using System;
using SharedCode;

namespace ControlStructures
{
    public class Conditions
    {
        public static void Demonstrate()
        {
            DemonstrateIf();
            DemonstrateIfElse();
            DemonstrateIfElseIf();
            DemonstrateSwitch();
            DemonstrateSwitchFallThrough();
        }

        public enum FileState
        {
            FileReadOk = 0,
            FileContainsErrors = 1,
            FileNotFound = 2
        }

        private static void SwitchFallThroughRealisticIsh()
        {
            var fileState = FileState.FileContainsErrors;

            switch (fileState)
            {
                    case FileState.FileReadOk:
                        Console.WriteLine("File read was OK!");
                        break;
                    case FileState.FileContainsErrors:
                    case FileState.FileNotFound:
                        Console.WriteLine("There was a problem with the file");
                        break;
                    default:
                        break;
            }
        }

        private static void IfRealisticIsh()
        {
            var fileState = FileState.FileContainsErrors;

            if (fileState == FileState.FileReadOk)
            {
                Console.WriteLine("File read was OK!");
            }
            else if (fileState == FileState.FileNotFound || fileState == FileState.FileContainsErrors)
            {
                Console.WriteLine("There was a problem with the file");
            }
            else
            {
                
            }
        }

        private static void DemonstrateSwitchFallThrough()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateSwitchFallThrough));

            var name = "Alice";

            switch (name)
            {
                case "Alice":
                case "Bob":
                    Console.WriteLine("You are either Alice or Bob!");
                    break;
                default:
                    Console.WriteLine("You are someone else!");
                    break;
            }
        }

        private static void DemonstrateSwitch()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateSwitch));

            var name = "Carol";

            switch (name)
            {
                case "Alice":
                    Console.WriteLine("You are Alice!");
                    break;
                case "Bob":
                    Console.WriteLine("You are Bob!");
                    break;
                default:
                    Console.WriteLine("You are someone else!");
                    break;
            }
        }

        private static void DemonstrateIfElseIf()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateIfElseIf));

            var i = 10;
            var j = 100;

            if (i > 100)
            {
                Console.WriteLine($"{i} is greater than 100");
            }
            else if (i > 10)
            {
                Console.WriteLine($"{i} is greater than 10");
            }
            else if (i > 5)
            {
                Console.WriteLine($"{i} is greater than 5");
            }

            if (j > 5)
            {
                Console.WriteLine($"{j} is greater than 5");
            }
            else if (j > 10)
            {
                Console.WriteLine($"{j} is greater then 10");
            }
            else if (j > 100)
            {
                Console.WriteLine($"{j} is greater then 100");
            }
        }

        private static void DemonstrateIfElse()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateIfElse));

            var i = 10;
            var j = 100;

            if (i > 5)
            {
                Console.WriteLine($"{i} is greater than 5");
            }
            else
            {
                Console.WriteLine($"{i} is not greater than 5");
            }

            if (i > 10)
            {
                Console.WriteLine($"{i} is greater then 10");
            }
            else
            {
                Console.WriteLine($"{i} is not greater than 10");
            }

            if (j > 5)
            {
                Console.WriteLine($"{j} is greater than 5");
            }
            else
            {
                Console.WriteLine($"{j} is not greater than 5");
            }

            if (j > 10)
            {
                Console.WriteLine($"{j} is greater then 10");
            }
            else
            {
                Console.WriteLine($"{j} is not greater than 10");
            }

            if (j > 100)
            {
                Console.WriteLine($"{j} is greater then 100");
            }
            else
            {
                Console.WriteLine($"{j} is not greater than 100");
            }
        }

        private static void DemonstrateIf()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateIf));

            var i = 10;
            var j = 100;

            if (i > 5)
            {
                Console.WriteLine($"{i} is greater than 5");
            }

            if (i > 10)
            {
                Console.WriteLine($"{i} is greater then 10");
            }

            if (j > 5)
            {
                Console.WriteLine($"{j} is greater than 5");
            }

            if (j > 10)
            {
                Console.WriteLine($"{j} is greater then 10");
            }

            if (j > 100)
            {
                Console.WriteLine($"{j} is greater then 100");
            }
        }
    }
}