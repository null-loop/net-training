using System;
using SharedCode;

namespace Operators
{
    public static class MultiplicationOperators
    {
        public static void Demonstrate()
        {
            DemonstrateMultiplyingIntByInt();
            DemonstrateMultiplyingIntByDecimal();
            DemonstrateOverflow();
        }

        private static void DemonstrateOverflow()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateOverflow));

            var x = int.MaxValue - 1000;
            var y = 2;
            var z = x * y;

            Console.WriteLine($"x * y ({x} * {y}) = z ({z})");
        }

        private static void DemonstrateMultiplyingIntByDecimal()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateMultiplyingIntByDecimal));

            var x = 1000;
            var y = 1.5m;
            var z = x * y;

            Console.WriteLine($"x * y ({x} * {y}) = z ({z})");
        }

        private static void DemonstrateMultiplyingIntByInt()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateMultiplyingIntByInt));

            var x = 1000;
            var y = 10;
            var z = x * y;

            Console.WriteLine($"x * y ({x} * {y}) = z ({z})");
        }
    }
}