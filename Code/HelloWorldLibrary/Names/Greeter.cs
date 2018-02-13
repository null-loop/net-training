using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorldLibrary
{
    public class Greeter
    {
        public static string FormatGreeting(string[] names)
        {
            if (names.Length == 0)
            {
                return "Hello World!";
            }

            var allNames = JoinStrings(names);
            
            return $"Hello {allNames}!";

        }

        private static string JoinStrings(string[] names)
        {
            return string.Join(" and ", names);
        }
    }
}
