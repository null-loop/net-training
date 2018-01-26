using System;
using System.Text;

namespace SharedCode
{
    public static class ConsoleHelper
    {
        public static void WriteHeading(string heading)
        {
            var spacedHeading = IntroduceSpacesOnCapitals(heading);

            var underline = new string('*', spacedHeading.Length);
            Console.WriteLine();
            Console.WriteLine(spacedHeading);
            Console.WriteLine(underline);
            Console.WriteLine();
        }

        private static string IntroduceSpacesOnCapitals(string heading)
        {
            var builder = new StringBuilder();

            for (int i = 0; i != heading.Length; i++)
            {
                var c = heading[i];
                if (char.IsUpper(c) && i > 0)
                {
                    builder.Append(' ');
                }
                builder.Append(c);
            }

            return builder.ToString();
        }
    }
}