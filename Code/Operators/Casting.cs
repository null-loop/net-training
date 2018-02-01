using System;
using System.Collections.Generic;
using SharedCode;

namespace Operators
{
    public static class Casting
    {
        public static void Demonstrate()
        {
            DemonstrateValueTypeCasting();
            DemonstrateReferenceTypeCasting();
        }

        private static void DemonstrateReferenceTypeCasting()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateReferenceTypeCasting));

            var a = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8};

            Console.WriteLine($"a is a {a.GetType()}");

            var b = a as IEnumerable<int>;

            Console.WriteLine($"b is a {b.GetType()}");

            var c = a as IEnumerable<decimal>;

            if (c == null)
            {
                Console.WriteLine("Oooops that cast didn't work!");
            }
        }

        private static void DemonstrateValueTypeCasting()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateValueTypeCasting));

            var x = 100;

            Console.WriteLine($"x is a {x.GetType()} and has the value {x}");

            var y = (decimal) x;

            Console.WriteLine($"y is a {y.GetType()} and has the value {y}");

            var a = 100.5m;

            Console.WriteLine($"a is a {a.GetType()} and has the value {a}");

            // avoid this kind of cast - control how the fractional part is lost using Math functions.
            var b = (int) a;

            Console.WriteLine($"b is a {b.GetType()} and has the value {b}");

            var c = decimal.MaxValue;

            Console.WriteLine($"c is a {c.GetType()} and has the value {c}");

            try
            {
                var d = (int) c;

                Console.WriteLine($"d is a {d.GetType()} and has the value {d}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}