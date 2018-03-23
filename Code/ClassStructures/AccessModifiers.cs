using System;
using System.Reflection;
using SharedCode;

namespace ClassStructures
{
    internal static class AccessModifiers
    {
        public static void Demonstrate()
        {
            DemonstrateSubvertingAccessModifiers();
        }

        private static void DemonstrateSubvertingAccessModifiers()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateSubvertingAccessModifiers));

            var encapsulated = new Encapsulated(Guid.NewGuid());

            Console.WriteLine($"My ID is {encapsulated}");

            // use reflection to find the field _id and change it's value
            var fieldInfo = encapsulated.GetType().GetField("_id", BindingFlags.NonPublic | BindingFlags.Instance);
            fieldInfo?.SetValue(encapsulated, Guid.NewGuid());

            Console.WriteLine($"Now my ID is {encapsulated}");
        }
    }
}