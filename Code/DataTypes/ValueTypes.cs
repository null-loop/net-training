using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedCode;

namespace DataTypes
{
    public static class ValueTypes
    {
        public static void Demonstrate()
        {
            DemonstrateValueTypeImmutabilityByValueAssignment();
            DemonstrateValueTypeImmutabilityByPassing();
            DemonstrateFloatingPointPrecisionLoss();
            DemonstrateNullValueTypes();
        }

        private static void DemonstrateNullValueTypes()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateNullValueTypes));

            var numbers = new List<int?> { 1, 2, 3, 4, 5, 6 };
            var seven = numbers.FirstOrDefault(n => n == 7);

            // there is no number 7 in our list - so what's in seven is NULL
            // guess what the rules for interacting with nullable value types are different to reference types...
            // below we WON'T get an error! But nothing is going to happen!
            var eight = seven + 1;
            Console.WriteLine(eight);

            // you can test it against null
            if (seven == null)
            {
                Console.WriteLine("seven is null");
            }

            if (eight == null)
            {
                Console.WriteLine("eight is null as well!");
            }

            // and also check the HasValue property...
            if (!seven.HasValue)
            {
                Console.WriteLine("seven has no value");
            }

            if (!eight.HasValue)
            {
                Console.WriteLine("eight has no value as well!");
            }
        }





        private static void DemonstrateValueTypeImmutabilityByValueAssignment()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateValueTypeImmutabilityByValueAssignment));

            // even though we assign k to be i it's not the same number
            // when we increment i - it doesn't change k

            var i = 0;
            var k = i;
            i++;
            Console.WriteLine($"i = {i}, k = {k}");
        }

        private static void DemonstrateValueTypeImmutabilityByPassing()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateValueTypeImmutabilityByPassing));

            var x = 0;

            Console.WriteLine($"x starts as {x}");

            DoSomethingWithX(x);

            Console.WriteLine($"x is still {x}");
        }

        private static void DoSomethingWithX(int x)
        {
            x = x + 10;
            Console.WriteLine($"I made x into {x}");
        }

        static void DemonstrateFloatingPointPrecisionLoss()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateFloatingPointPrecisionLoss));

            var f = 3653737.2515F;
            f = f - .2514F;
            Console.WriteLine($"f = {f:G11}");
            // that should be 3653737.2515F.0001 - we've lost precision!
        }
    }
}
