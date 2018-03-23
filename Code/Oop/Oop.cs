using System;
using System.Collections.Generic;
using ClassStructures;
using SharedCode;

namespace Oop
{
    public static class Oop
    {
        public static void Demonstrate()
        {
            //DemonstrateIEnumerableUsage();
            //DemonstrateInterfacePolymorphism();
            DemonstrateInheritancePolymorphism();
        }

        private static void DemonstrateInheritancePolymorphism()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateInheritancePolymorphism));

            var bunchOfBananas = new Bunch<Banana>(new []{new Banana(), new Banana(), new Banana() });
            var bunchOfGrapes = new Bunch<Grape>(new[] {new Grape(), new Grape(), new Grape(), new Grape() });
            var bunchOfCarrots = new Bunch<Carrot>(new[] {new Carrot(), new Carrot()});
            var beef = new Beef();
            var pork = new Pork();

            var trex = new TRex();
            var squirrel = new Squirrel();
            var human = new Human();

            Feed(squirrel, bunchOfBananas);
            Feed(squirrel, bunchOfGrapes);
            Feed(squirrel, bunchOfCarrots);

            Feed(human, squirrel);
            Feed(human, beef);
            Feed(human, pork);

            Feed(trex, human);
        }

        private static void Feed(IEat eater, IFood food)
        {
            var soundMaker = eater as IMakeSounds;
            Console.WriteLine();
            Console.WriteLine($"Trying to feed {food} (which belongs to the {food.FoodGroup} group, with a food value of {food.FoodValue}) to a {eater}");
            Console.WriteLine($"Which is something it {(eater.CanEat(food) ? "can" : "cannot")} eat");
            if (eater == food)
            {
                Console.WriteLine("Unfortunately it cannot eat itself");
                return;
            }
            Console.WriteLine($"Currently the {eater} has a food level of {eater.FoodLevel}");
            try
            {
                eater.Eat(food);
                Console.WriteLine($"The {eater} ate the {food}");
                WriteSound(soundMaker, s=>s.Contentment());
                Console.WriteLine($"Now its food level is {eater.FoodLevel}");
            }
            catch (Exception e)
            {
                WriteSound(soundMaker, s => s.Surprise());
                Console.WriteLine(e);
            }
        }

        private static void WriteSound(IMakeSounds soundMaker, Func<IMakeSounds, string> sound)
        {
            if (soundMaker != null)
            {
                Console.WriteLine($"*** {sound(soundMaker)} ***");
            }
        }

        private static void DemonstrateInterfacePolymorphism()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateInterfacePolymorphism));

            var cat = new Cat();
            var dog = new Dog();

            MakeSounds(cat);
            MakeSounds(dog);
        }

        private static void MakeSounds(IMakeSounds soundMaker)
        {
            Console.WriteLine($"A surprised {soundMaker.GetType().Name} makes the sound {soundMaker.Surprise()}");
            Console.WriteLine($"A contented {soundMaker.GetType().Name} makes the sound {soundMaker.Contentment()}");
        }

        private static void DemonstrateIEnumerableUsage()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateIEnumerableUsage));

            var people = new List<Person>
            {
                new Person("Bob", DateTime.Today),
                new Person("Alice", DateTime.Today),
                new Person("Carol", DateTime.Now),
                new Person("David", DateTime.Now)
            };

            var peopleWithAInTheirName = people.WhereEnumerable(p=>p.FirstName.Contains("A") || p.FirstName.Contains("a"));

            foreach (var person in peopleWithAInTheirName)
            {
                Console.WriteLine($"{person.FirstName} has A or a in their name!");
            }
        }
    }
}