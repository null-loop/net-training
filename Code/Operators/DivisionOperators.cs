using System;
using SharedCode;

namespace Operators
{
    public static class DivisionOperators
    {
        public static void Demonstrate()
        {
            DemonstrateDividingIntByInt();
            DemonstrateDividingIntByDecimal();
            DemonstrateDividingIntByIntAndLosingFraction();
            DemonstrateDividingIntByIntAndNotLosingFraction();
        }

        private static void DemonstrateDividingIntByIntAndNotLosingFraction()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateDividingIntByIntAndNotLosingFraction));

            var x = 1000;
            var y = 3;
            var z = x / (decimal)y;

            Console.WriteLine($"x / y ({x} / {y}) = z ({z})");
        }

        private static void DemonstrateDividingIntByIntAndLosingFraction()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateDividingIntByIntAndLosingFraction));

            var x = 1000;
            var y = 3;
            var z = x / y;

            Console.WriteLine($"x / y ({x} / {y}) = z ({z})");
        }

        private static void DemonstrateDividingIntByDecimal()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateDividingIntByDecimal));

            var x = 1000;
            var y = 3m;
            var z = x / y;

            Console.WriteLine($"x / y ({x} / {y}) = z ({z})");
        }

        private static void DemonstrateDividingIntByInt()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateDividingIntByInt));

            var x = 1000;
            var y = 10;
            var z = x / y;

            Console.WriteLine($"x / y ({x} / {y}) = z ({z})");
        }
    }
}