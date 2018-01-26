using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedCode;

namespace DataTypes
{
    public static class Collections
    {
        public static void Demonstrate()
        {
            DemonstrateList();
            DemonstrateArray();
            DemonstrateDictionary();
            DemonstrateQueue();
            DemonstrateStack();
        }

        private static void DemonstrateStack()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateStack));
            var peopleStack = new Stack<Person>();

            var alice = new Person("Alice");
            var bob = new Person("Bob");
            var carol = new Person("Carol");

            peopleStack.Push(alice);
            peopleStack.Push(bob);
            peopleStack.Push(carol);

            PrintCollection(peopleStack);

            // who's first?
            var first = peopleStack.Pop();
            Console.WriteLine(first);

            var second = peopleStack.Pop();
            Console.WriteLine(second);

            var third = peopleStack.Pop();
            Console.WriteLine(third);
        }

        private static void DemonstrateQueue()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateQueue));
            var peopleQueue = new Queue<Person>();

            var alice = new Person("Alice");
            var bob = new Person("Bob");
            var carol = new Person("Carol");

            peopleQueue.Enqueue(alice);
            peopleQueue.Enqueue(bob);
            peopleQueue.Enqueue(carol);

            PrintCollection(peopleQueue);

            // who leaves the queue first?
            var first = peopleQueue.Dequeue();
            Console.WriteLine(first);

            var second = peopleQueue.Dequeue();
            Console.WriteLine(second);

            var third = peopleQueue.Dequeue();
            Console.WriteLine(third);
        }

        private static void DemonstrateDictionary()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateDictionary));

            // dictionaries have two "sub" types - a key, and a value
            // here we've created a dictionary of Person objects keyed to a string
            var people = new Dictionary<string, Person>();

            var alice = new Person("Alice");
            var bob = new Person("Bob");
            var carol = new Person("Carol");

            people.Add(alice.Name, alice);
            people.Add(bob.Name, bob);
            people.Add(carol.Name, carol);

            PrintCollection(people);

            // we then find things in the dictionary by the key - finding them this way is FAST
            // imagine a list of 1,000 people and the person you want is the last one in the list
            // you have to search 1,000 people before you find them
            // dictionaries jump you straight to the person you're after
            var foundAlice = people["Alice"];

            Console.WriteLine($"Look who I found : {foundAlice}");

            // we also remove them by key
            people.Remove("Bob");
            PrintCollection(people);

            // we can clear them as well
            people.Clear();
            PrintCollection(people);
        }

        private static void DemonstrateArray()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateArray));

            var array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            PrintCollection(array);

            // we can't add - or remove - but we CAN substitute
            array[0] = 9;

            PrintCollection(array);
        }

        private static void DemonstrateList()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateList));

            // this syntax is collection initialisation - we've created a list of integers with the
            // numbers 1 - 8
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };

            PrintCollection(list);

            // add 9 and 10
            list.Add(9);
            list.Add(10);

            PrintCollection(list);

            // note lists are ordered in the order we add things - not the natural order of the things
            list.Add(13);
            list.Add(12);
            list.Add(11);

            PrintCollection(list);

            // and they can be added more than once
            list.Add(11);
            list.Add(11);
            PrintCollection(list);

            // we can remove things - but only one of them (the first one it finds)!
            list.Remove(11);
            PrintCollection(list);

            // we can also remove them all the ones that match
            list.RemoveAll(i => i == 11);
            PrintCollection(list);

            // we can insert in arbitary places
            list.Insert(0, 0);
            PrintCollection(list);

            // we can remove from arbitary places
            list.RemoveAt(11);
            PrintCollection(list);

            // and we can empty them
            list.Clear();
            PrintCollection(list);
        }

        private static void PrintCollection<T>(IEnumerable<T> collection)
        {
            var array = collection.ToArray();
            Console.WriteLine($"Contains {array.Length} entries");
            if (array.Any())
            {
                Console.WriteLine(string.Join(", ", array));
            }
        }
    }
}
