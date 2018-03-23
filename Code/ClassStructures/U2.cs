using System;
using System.Collections.Generic;
using System.Text;

namespace ClassStructures
{
    public static class U2
    {
        private static readonly List<Person> _members;

        static U2()
        {
            _members = new List<Person>
            {
                new Person("Paul", "Hewson", new DateTime(1960, 5, 10)),
                new Person("David", "Evans", new DateTime(1961, 8, 8)),
                new Person("Adam", "Clayton", new DateTime(1960, 3, 13)),
                new Person("Larry", "Mullen", new DateTime(1961, 10, 31))
            };
        }

        public static string ListMembers()
        {
            var builder = new StringBuilder();

            builder.AppendLine("The current members of U2 are:");
            foreach (var member in _members)
            {
                builder.AppendLine($"* {member}");
            }

            return builder.ToString();
        }

        public static Person[] GetMembers()
        {
            return _members.ToArray();
        }
    }
}