using System;
using SharedCode;

namespace Operators
{
    public static class AdditionOperators
    {
        public static void Demonstrate()
        {
            DemonstrateAddingIntToInt();
            DemonstrateAddingIntToDecimal();
            DemonstrateOverflow();
        }

        private static void DemonstrateOverflow()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateOverflow));

            var x = int.MaxValue;
            var y = 10;
            var z = x + y;

            Console.WriteLine($"x + y ({x} + {y}) = z ({z})");
        }

        private static void DemonstrateAddingIntToDecimal()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateAddingIntToDecimal));
            var x = 10.5m;
            var y = 10;
            var z = x + y;
            Console.WriteLine($"x + y ({x} + {y}) = z ({z})");
        }

        private static void DemonstrateAddingIntToInt()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateAddingIntToInt));
            var x = 10;
            var y = 10;
            var z = x + y;
            Console.WriteLine($"x + y ({x} + {y}) = z ({z})");
        }
    }
}