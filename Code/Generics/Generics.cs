using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Generics.Container;
using SharedCode;

namespace Generics
{
    public static class Generics
    {
        public static void Demonstrate()
        {
            //DemonstrateTypeCastErrorsWithArrayLists();
            //DemonstrateInabilityToPutIntsInListOfDateTime();
            //DemonstrateUseOfLazy();
            DemonstrateUseOfIocContainer();
            //DemonstrateSimpleSingletons();
            //DemonstrateFactorySingletons();
            //DemonstrateConstructorLocatorSingletons();
        }

        private static void DemonstrateInabilityToPutIntsInListOfDateTime()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateInabilityToPutIntsInListOfDateTime));

            var dateTimes = new List<DateTime>();
            dateTimes.Add(new DateTime(2018,1,1));
            //dateTimes.Add(1234);
        }

        private static void DemonstrateUseOfIocContainer()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateUseOfIocContainer));

            var container = new IocContainer();

            container.Register<IOutputWriter, ConsoleOutputWriter>();
            container.Register<FunctionExecutor>();

            var executor = container.Resolve<FunctionExecutor>();
            //executor.Execute(DoSomething);
            executor.Execute(() => DoSomething());
        }

        private static void DemonstrateSimpleSingletons()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateSimpleSingletons));

            var container = new IocContainer();
            
            container.RegisterSingleton(new ChesneyHawkes());

            var chesney = container.Resolve<ChesneyHawkes>();
            var chesneyTwo = container.Resolve<ChesneyHawkes>();

            Console.WriteLine($"chesney == chesneyTwo ({chesney == chesneyTwo})");
        }

        private static void DemonstrateFactorySingletons()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateFactorySingletons));

            var container = new IocContainer();

            container.RegisterSingleton(() => new ChesneyHawkes());

            var chesney = container.Resolve<ChesneyHawkes>();
            var chesneyTwo = container.Resolve<ChesneyHawkes>();

            Console.WriteLine($"chesney == chesneyTwo ({chesney == chesneyTwo})");
        }

        private static void DemonstrateConstructorLocatorSingletons()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateConstructorLocatorSingletons));

            var container = new IocContainer();

            container.Register<IOutputWriter, ConsoleOutputWriter>();
            container.RegisterSingleton<Highlander>();

            var highlander = container.Resolve<Highlander>();
            var highlanderTwo = container.Resolve<Highlander>();

            Console.WriteLine($"highlander == highlanderTwo ({highlander == highlanderTwo})");
        }
        
        private static string DoSomething()
        {
            Console.WriteLine("I'm doing something...");
            return "This is my result!";
        }

        private static void DemonstrateUseOfLazy()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateUseOfLazy));

            var lazyInteger = new Lazy<int>(() =>
            {
                var x = 0;
                Console.WriteLine($"I'm getting my value ({x})!");
                return x;
            });

            Console.WriteLine("I've created lazyInteger");

            var lazyString = new Lazy<string>(() =>
            {
                var s = "Hello there";
                Console.WriteLine($"I'm getting my value ({s})!");
                return s;
            });

            Console.WriteLine("I've created lazyString");

            Console.WriteLine($"lazyInteger = {lazyInteger.Value}");
            Console.WriteLine($"lazyInteger = {lazyInteger.Value}");

            Console.WriteLine($"lazyString = {lazyString.Value}");
            Console.WriteLine($"lazyString = {lazyString.Value}");           
        }

        private static void DemonstrateTypeCastErrorsWithArrayLists()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateTypeCastErrorsWithArrayLists));

            // create an array list and add different types to it.
            var arrayList = new ArrayList();

            arrayList.Add(new DateTime(2017, 10, 01));
            arrayList.Add(1234);
            arrayList.Add(1234m);
            arrayList.Add(1234L);

            // try retrieving values - they all come out as objects
            foreach (var entry in arrayList)
            {
                Console.WriteLine(entry.GetType().FullName);

                try
                {
                    var dateTime = (DateTime) entry;
                    Console.WriteLine($"DateTime = {dateTime}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
