using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SharedCode;

namespace ControlStructures
{
    public class Loops
    {
        public static void Demonstrate()
        {
            DemonstrateWhile();
            DemonstrateWhileWithNoEntry();
            DemonstrateDoWhile();
            DemonstrateFor();
            DemonstrateForEach();
            DemonstrateBreakingForEach();
            DemonstrateCorrectRemovalFromListWhilstEnumerating();
            DemonstrateContinue();
            DemonstrateBreak();
        }

        private static void DemonstrateBreakingForEach()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateBreakingForEach));

            var things = new List<string> { "First", "Second", "Third" };

            foreach (var thing in things)
            {
                if (thing == "Second")
                {
                    things.Remove(thing);
                }
            }
        }

        private static void DemonstrateCorrectRemovalFromListWhilstEnumerating()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateCorrectRemovalFromListWhilstEnumerating));

            var things = new List<string> {"First", "Second", "Third"};
            var thingsToEnumerate = things.ToArray();

            foreach (var thing in thingsToEnumerate)
            {
                if (thing == "Second")
                {
                    things.Remove(thing);
                }
            }
        }

        private static void DemonstrateBreak()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateBreak));

            var things = new string[] {"First", "Second", "Third"};
            var lookingFor = "Second";

            foreach (var thing in things)
            {
                Console.WriteLine($"Checking {thing}");
                
                if (thing == lookingFor)
                {
                    Console.WriteLine("Found it!");
                    break;
                }
            }
        }

        private static void DemonstrateContinue()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateContinue));

            var things = new string[] { "First", "Second", "Third", "Second" };
            var lookingFor = "Second";

            foreach (var thing in things)
            {
                Console.WriteLine($"Checking {thing}");

                if (thing != lookingFor) continue;

                Console.WriteLine($"Now I have you {thing}");

                // Do something complicated with thing...
            }
        }

        private static void DemonstrateForEach()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateForEach));

            var things = new string[] {"First", "Second", "Third"};

            Console.WriteLine("Forwards...");
            Console.WriteLine();

            foreach (var thing in things)
            {
                Console.WriteLine(thing);
            }

            Console.WriteLine();
            Console.WriteLine("Backwards...");
            Console.WriteLine();

            var backwards = things.Reverse().ToArray();
            foreach (var thing in backwards)
            {
                Console.WriteLine(thing);
            }
        }

        private static void DemonstrateFor()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateFor));

            var things = new string[] { "First", "Second", "Third" };

            Console.WriteLine("Forwards...");
            Console.WriteLine();

            for (var i = 0; i != things.Length; i++)
            {
                Console.WriteLine(things[i]);
            }

            Console.WriteLine();
            Console.WriteLine("Backwards...");
            Console.WriteLine();

            for (var i = things.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(things[i]);
            }
        }

        private static void DemonstrateDoWhile()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateDoWhile));

            // wait until they've pressed a key
            var keyPressed = false;
            var writeMessageGuard = 100000;
            var writeMessageCount = 0;
            var stopWatch = Stopwatch.StartNew();

            do
            {
                if (writeMessageCount % writeMessageGuard == 0)
                {
                    Console.WriteLine("Come on - press a damn key...");
                    writeMessageCount = 0;
                }
                if (Console.KeyAvailable)
                {
                    stopWatch.Stop();
                    Console.WriteLine($"At last! We waited {stopWatch.Elapsed.TotalSeconds:#,###.00} seconds for you to press something!");
                    keyPressed = true;
                }

                writeMessageCount++;
            } while (!keyPressed);
        }

        public static void DemonstrateWhileWithNoEntry()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateWhileWithNoEntry));

            Console.WriteLine("Press A - for further instructions");
            Console.WriteLine("Press any other key to exit");

            var lastKey = Console.ReadKey(true);

            while (lastKey.Key == ConsoleKey.A)
            {
                Console.WriteLine("Press A to keep waiting for further instructions");
                Console.WriteLine("Press any other key to exit");
                lastKey = Console.ReadKey(true);
            }

            Console.WriteLine("Goodbye then....");
        }

        public static void DemonstrateWhile()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateWhile));

            // wait until they've pressed a key
            var keyPressed = false;
            var writeMessageGuard = 100000;
            var writeMessageCount = 0;
            var stopWatch = Stopwatch.StartNew();

            while (!keyPressed)
            {
                var remainder = writeMessageCount % writeMessageGuard;
                if (remainder == 0)
                {
                    Console.WriteLine("Come on - press a damn key...");
                    writeMessageCount = 0;
                }
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    stopWatch.Stop();
                    Console.WriteLine($"At last! We waited {stopWatch.Elapsed.TotalSeconds:#,###.00} seconds for you to press something (specifically - you pressed {key.KeyChar})!");
                    keyPressed = true;
                }

                writeMessageCount++;
            }
        }
    }
}