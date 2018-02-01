using System;
using SharedCode;

namespace Operators
{
    public static class SubtractionOperators
    {
        public static void Demonstrate()
        {
            DemonstrateSubtractingIntFromInt();
            DemonstrateSubtractingIntFromDecimal();
            DemonstrateUnderflow();
        }

        private static void DemonstrateUnderflow()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateUnderflow));

            var x = int.MinValue;
            var y = 10;
            var z = x - y;

            Console.WriteLine($"x - y ({x} - {y}) = z ({z})");
        }

        private static void DemonstrateSubtractingIntFromDecimal()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateSubtractingIntFromDecimal));

            var x = 100.5m;
            var y = 10;
            var z = x - y;

            Console.WriteLine($"x - y ({x} - {y}) = z ({z})");
        }

        private static void DemonstrateSubtractingIntFromInt()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateSubtractingIntFromInt));

            var x = 100;
            var y = 10;
            var z = x - y;

            Console.WriteLine($"x - y ({x} - {y}) = z ({z})");
        }
    }
}