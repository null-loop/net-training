using System;
using SharedCode;

namespace Operators
{
    public static class IncrementOperators
    {
        public static void Demonstrate()
        {
            DemonstrateIncrementingInt();
            DemonstrateIncrementingDecimal();
            DemonstrateOverflow();
        }

        private static void DemonstrateOverflow()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateOverflow));

            var x = int.MaxValue;
            Console.WriteLine($"x = {x}");
            x++;
            Console.WriteLine($"x++ = {x}");
        }

        private static void DemonstrateIncrementingDecimal()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateIncrementingDecimal));

            var x = 10.5m;
            Console.WriteLine($"x = {x}");
            x++;
            Console.WriteLine($"x++ = {x}");
        }

        private static void DemonstrateIncrementingInt()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateIncrementingInt));

            var x = 10;
            Console.WriteLine($"x = {x}");
            x++;
            Console.WriteLine($"x++ = {x}");
        }
    }
}