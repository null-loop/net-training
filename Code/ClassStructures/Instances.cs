using System;
using SharedCode;

namespace ClassStructures
{
    internal static class Instances
    {
        public static void Demonstrate()
        {
            //DemonstrateConstructors();
            //DemonstrateOverloads();
            DemonstrateEvents();
        }

        private static void DemonstrateOverloads()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateOverloads));

            var paulHewson = new Person("Paul", "Hewson", new DateTime(1960, 5, 10));

            Console.WriteLine(paulHewson);

            var ageLastYear = paulHewson.CalculateAgeInYears(DateTime.UtcNow.AddYears(-1));

            Console.WriteLine($"A year ago I was {ageLastYear} years old");
        }

        private static void DemonstrateEvents()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateEvents));

            var paulHewson = new Person("Paul", "Hewson", new DateTime(1960, 5, 10));
            var davidEvans = new Person("David", "Evans", new DateTime(1961, 8, 8));

            Console.WriteLine(paulHewson);
            Console.WriteLine(davidEvans);

            paulHewson.NameChanged += Person_NameChanged;
            davidEvans.NameChanged += Person_NameChanged;
            Person.ANameChanged += SomeoneChangedTheirName;

            paulHewson.ChangeName("Bono");
            davidEvans.ChangeName("The Edge");

            Console.WriteLine(paulHewson);
            Console.WriteLine(davidEvans);
        }

        private static void SomeoneChangedTheirName(object sender, NameChangeEventArgs e)
        {
            Console.WriteLine("Someone changed their name");
        }

        private static void Person_NameChanged(object sender, NameChangeEventArgs e)
        {
            Console.WriteLine($"{Person.FormatNames(e.OldFirstName, e.OldLastName)} has changed their name to {Person.FormatNames(e.NewFirstName, e.NewLastName)}");
        }
        

        private static void DemonstrateConstructors()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateConstructors));

            var paulHewson = new Person("Paul", "Hewson", new DateTime(1960, 5, 10));
            
            Console.WriteLine(paulHewson);
        }
    }
}