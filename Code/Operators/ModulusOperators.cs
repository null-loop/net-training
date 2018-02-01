using System;
using SharedCode;

namespace Operators
{
    public static class ModulusOperators
    {
        public static void Demonstrate()
        {
            DemonstrateSimpleModulus();
            DemonstratePracticalApplication();
        }

        private static void DemonstratePracticalApplication()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstratePracticalApplication));

            var max = 1000000;
            var threshold = 100000;
            var i = 0;

            while (i <= max)
            {
                i++;
                if (i % threshold == 0)
                {
                    Console.WriteLine($"i = {i:#,###}");
                }
            }
        }

        private static void DemonstrateSimpleModulus()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateSimpleModulus));

            var x = 100;
            var y = 10;
            var z = x % y;
            Console.WriteLine($"x % y ({x} % {y}) = z ({z})");

            x = 100;
            y = 3;
            z = x % y;
            Console.WriteLine($"x % y ({x} % {y}) = z ({z})");
        }
    }
}