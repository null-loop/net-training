using System;
using System.Collections.Generic;
using System.Linq;
using ClassStructures;
using SharedCode;

namespace Linq
{
    public static class Linq
    {
        public static void Demonstrate()
        {
            //DemonstrateWhere();
            //DemonstrateSelect();
            //DemonstrateAny();
            //DemonstrateCount();
            //DemonstrateFirst();
            //DemonstrateFirstOrDefault();
            //DemonstrateSingle();

            //DemonstrateMyWhere();
            //DemonstrateMySelect();
            //DemonstrateMyCount();

            DemonstrateChaining();
        }

        private static void DemonstrateChaining()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateChaining));

            var people = new List<Person>
            {
                new Person("Bob", DateTime.Today),
                new Person("Alice", DateTime.Today),
                new Person("Carol", DateTime.Now),
                new Person("David", DateTime.Now)
            };

            var peopleWithAInTheirNames = people.MyWhere(p => p.FirstName.Contains("A") || p.FirstName.Contains("a"))
                .OrderBy(p=>p.CalculateAgeInYears())
                .ThenByDescending(p=>p.FirstName)
                .MySelect(p => p.FirstName);

            foreach (var person in peopleWithAInTheirNames)
            {
                Console.WriteLine($"{person} has A or a in their name!");
            }
        }

        private static void DemonstrateMyCount()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateMyCount));

            var people = new List<Person>
            {
                new Person("Bob", DateTime.Today),
                new Person("Alice", DateTime.Today),
                new Person("Carol", DateTime.Now),
                new Person("David", DateTime.Now)
            };

            var peopleCount = people.MyCount();

            Console.WriteLine($"There are {peopleCount} people in the list");

            var peopleWithAInTheirNameCount = people.MyCount(p => p.FirstName.Contains("A") || p.FirstName.Contains("a"));

            Console.WriteLine($"There are {peopleWithAInTheirNameCount} people with A or a in their name in the list");
        }

        private static void DemonstrateMySelect()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateMySelect));

            var people = new List<Person>
            {
                new Person("Bob", DateTime.Today),
                new Person("Alice", DateTime.Today),
                new Person("Carol", DateTime.Now),
                new Person("David", DateTime.Now)
            };

            var justFirstNames = people.MySelect(p => p.FirstName);

            foreach (var name in justFirstNames)
            {
                Console.WriteLine(name);
            }
        }

        private static void DemonstrateMyWhere()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateMyWhere));

            var people = new List<Person>
            {
                new Person("Bob", DateTime.Today),
                new Person("Alice", DateTime.Today),
                new Person("Carol", DateTime.Now),
                new Person("David", DateTime.Now)
            };

            var withAInName = people.MyWhere(p => p.FirstName.Contains("a") || p.FirstName.Contains("A"));

            foreach (var person in withAInName)
            {
                Console.WriteLine($"{person.FirstName} has A or a in their name!");
            }
        }

        private static void DemonstrateSingle()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateSingle));

            var people = new List<Person>
            {
                new Person("Bob", DateTime.Today),
                new Person("Alice", DateTime.Today),
                new Person("Carol", DateTime.Now),
                new Person("David", DateTime.Now)
            };

            var singleBob = people.Single(p => p.FirstName == "Bob");

            Console.WriteLine($"The only person called Bob is {singleBob.FirstName}");

            try
            {
                var singleWithAInTheirName = people.Single(p => p.FirstName.Contains("A") || p.FirstName.Contains("a"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void DemonstrateFirstOrDefault()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateFirstOrDefault));

            var people = new List<Person>
            {
                new Person("Bob", DateTime.Today),
                new Person("Alice", DateTime.Today),
                new Person("Carol", DateTime.Now),
                new Person("David", DateTime.Now)
            };

            var firstPersonCalledSam = people.FirstOrDefault(p => p.FirstName == "Sam");

            if (firstPersonCalledSam == null)
            {
                Console.WriteLine("There was no one called sam in the list!");
            }
        }

        private static void DemonstrateFirst()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateFirst));

            var people = new List<Person>
            {
                new Person("Bob", DateTime.Today),
                new Person("Alice", DateTime.Today),
                new Person("Carol", DateTime.Now),
                new Person("David", DateTime.Now)
            };

            var firstPerson = people.First();

            Console.WriteLine($"The first person in the list is {firstPerson.FirstName}");

            try
            {
                var firstPersonCalledSam = people.First(p => p.FirstName == "Sam");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void DemonstrateCount()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateCount));

            var people = new List<Person>
            {
                new Person("Bob", DateTime.Today),
                new Person("Alice", DateTime.Today),
                new Person("Carol", DateTime.Now),
                new Person("David", DateTime.Now)
            };

            var peopleCount = people.Count();

            Console.WriteLine($"There are {peopleCount} people in the list");

            var peopleWithAInTheirNameCount = people.Count(p => p.FirstName.Contains("A") || p.FirstName.Contains("a"));

            Console.WriteLine($"There are {peopleWithAInTheirNameCount} people with A or a in their name in the list");
        }

        private static void DemonstrateAny()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateAny));

            var people = new List<Person>
            {
                new Person("Bob", DateTime.Today),
                new Person("Alice", DateTime.Today),
                new Person("Carol", DateTime.Now),
                new Person("David", DateTime.Now)
            };

            var anyPeople = people.Any();

            Console.WriteLine($"It is {anyPeople} that there are any people in the list");

            var anyoneCalledSam = people.Any(p => p.FirstName == "Sam");

            Console.WriteLine($"It is {anyoneCalledSam} that there are any people called Sam in the list");
        }

        private static void DemonstrateSelect()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateSelect));

            var people = new List<Person>
            {
                new Person("Bob", DateTime.Today),
                new Person("Alice", DateTime.Today),
                new Person("Carol", DateTime.Now),
                new Person("David", DateTime.Now)
            };

            var justFirstNames = people.Select(p => p.FirstName);

            foreach (var name in justFirstNames)
            {
                Console.WriteLine(name);
            }
        }

        private static void DemonstrateWhere()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateWhere));

            var people = new List<Person>
            {
                new Person("Bob", DateTime.Today),
                new Person("Alice", DateTime.Today),
                new Person("Carol", DateTime.Now),
                new Person("David", DateTime.Now)
            };

            var withAInName = people.Where(p => p.FirstName.Contains("a") || p.FirstName.Contains("A"));
             
            foreach (var person in withAInName)
            {
                Console.WriteLine($"{person.FirstName} has A or a in their name!");
            }
        }
    }
}