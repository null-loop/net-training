using System;
using SharedCode;

namespace Operators
{
    public static class DecrementOperators
    {
        public static void Demonstrate()
        {
            DemonstrateDecrementingInt();
            DemonstrateDecrementingDecimal();
            DemonstrateUnderflow();
        }

        private static void DemonstrateUnderflow()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateUnderflow));

            var x = int.MinValue;
            Console.WriteLine($"x = {x}");
            x--;
            Console.WriteLine($"x-- = {x}");
        }

        private static void DemonstrateDecrementingDecimal()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateDecrementingDecimal));

            var x = 10.5m;
            Console.WriteLine($"x = {x}");
            x--;
            Console.WriteLine($"x-- = {x}");
        }

        private static void DemonstrateDecrementingInt()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateDecrementingInt));

            var x = 10;
            Console.WriteLine($"x = {x}");
            x--;
            Console.WriteLine($"x-- = {x}");
        }
    }
}