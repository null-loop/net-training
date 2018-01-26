using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedCode;

namespace DataTypes
{
    public static class ReferenceTypes
    {
        public static void Demonstrate()
        {
            DemonstrateReferenceTypeMutabilityAndReferenceAssignment();
            DemonstrateNullReferenceTypes();
        }

        private static void DemonstrateNullReferenceTypes()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateNullReferenceTypes));
            var nameOfPersonToFind = "David";
            var people = new List<Person> { new Person("Alice"), new Person("Bob"), new Person("Carol") };
            var personToFind = people.FirstOrDefault(p => p.Name == nameOfPersonToFind);

            // there is no Person called David... what's stored in david is called NULL
            // if we try and interact with David we're going to get an exception - so let's be careful...
            try
            {
                Console.WriteLine(personToFind.Name);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ooops - that didn't work, where's David? : " + e.Message);
            }

            // instead we can test AGAINST null
            if (personToFind == null)
            {
                Console.WriteLine($"Couldn't find {nameOfPersonToFind}");
            }
            else
            {
                Console.WriteLine(personToFind.Name);
            }
        }

        private static void DemonstrateReferenceTypeMutabilityAndReferenceAssignment()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateReferenceTypeMutabilityAndReferenceAssignment));

            var counterOne = new MyCounter();
            // counterTwo is same object as counterone
            var counterTwo = counterOne;
            // so when we increment the value inside counterOne it's also updating what we get from counterTwo
            counterOne.Increment();

            Console.WriteLine($"counterOne = {counterOne.Value}, counterTwo = {counterTwo.Value}");

            counterOne.Increment();

            PrintMyValue(counterOne);

            Console.WriteLine($"counterOne = {counterOne.Value}, counterTwo = {counterTwo.Value}");
        }

        private static void PrintMyValue(MyCounter counter)
        {
            Console.WriteLine($"Value = {counter}");
            counter.Increment();
        }
    }
}
