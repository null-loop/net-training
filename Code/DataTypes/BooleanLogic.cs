using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedCode;

namespace DataTypes
{
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
