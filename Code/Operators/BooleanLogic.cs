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
            ConsoleHelper.WriteHeading(nameof(DemonstrateDividingIntByDecimal));

            var x = 1000;
            var y = 10;
            var z = x / y;

            Console.WriteLine($"x / y ({x} / {y}) = z ({z})");
        }
    }

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

    public static class BooleanLogic
    {
        public static void Demonstrate()
        {
            DemonstrateAnd();
            DemonstrateOr();
            DemonstrateNot();
        }

        private static void DemonstrateNot()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateNot));

            var a = false;
            var c = !a;

            Console.WriteLine($"a = {a}, c = {c}");

            a = true;
            c = !a;

            Console.WriteLine($"a = {a}, c = {c}");
        }

        private static void DemonstrateAnd()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateAnd));

            var a = false;
            var b = false;
            var c = a && b;

            Console.WriteLine($"a = {a}, b = {b}, c = {c}");

            a = true;
            b = false;
            c = a && b;

            Console.WriteLine($"a = {a}, b = {b}, c = {c}");

            a = false;
            b = true;
            c = a && b;

            Console.WriteLine($"a = {a}, b = {b}, c = {c}");

            a = true;
            b = true;
            c = a && b;

            Console.WriteLine($"a = {a}, b = {b}, c = {c}");
        }

        private static void DemonstrateOr()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateOr));

            var a = false;
            var b = false;
            var c = a || b;

            Console.WriteLine($"a = {a}, b = {b}, c = {c}");

            a = true;
            b = false;
            c = a || b;

            Console.WriteLine($"a = {a}, b = {b}, c = {c}");

            a = false;
            b = true;
            c = a || b;

            Console.WriteLine($"a = {a}, b = {b}, c = {c}");

            a = true;
            b = true;
            c = a || b;

            Console.WriteLine($"a = {a}, b = {b}, c = {c}");
        }
    }
}
