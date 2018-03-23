using System;
using System.Text;
using SharedCode;

namespace FuncsAndActions
{
    public static class FuncsAndActions
    {
        public static void Demonstrate()
        {
            DemonstrateLambdaSyntax();
            DemonstrateMethodGroupSyntax();
            DemonstrateLocalFunctions();
        }

        private static void DemonstrateLocalFunctions()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateLocalFunctions));

            string HelloFuncLocalFunction() => "Hello from a func!";
            Console.WriteLine(HelloFuncLocalFunction());

            PerformFunc(HelloFuncLocalFunction);
        }

        private static void PerformFunc(Func<string> func)
        {
            Console.WriteLine(func());
        }

        private static void DemonstrateMethodGroupSyntax()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateMethodGroupSyntax));

            Func<string> helloFunc = HelloFunction;
            Console.WriteLine(helloFunc());

            Func<int, string> formatterFunc = NumberFormatterFunction;
            Console.WriteLine(formatterFunc(1000));
        }

        private static string HelloFunction()
        {
            return "Hello from a static method wrapped in a func!";
        }

        private static string NumberFormatterFunction(int i)
        {
            return $"My value from a static method wrapped in a func {i:#,###}";
        }

        public static void DemonstrateLambdaSyntax()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateLambdaSyntax));

            Func<string> helloFunc = () => { return "Hello from a func!"; };
            Console.WriteLine(helloFunc());

            Func<int, string> formatFunc = (i) => { return $"My value is {i:#,###}"; };
            Console.WriteLine(formatFunc(1000));

            Action<StringBuilder> builderFunc = (b) =>
            {
                b.AppendLine("Hello");
                b.AppendLine("There");
                b.AppendLine("World");
                b.AppendLine("From an Action<StringBuilder>!");
            };
            var builder = new StringBuilder();
            builderFunc(builder);
            Console.WriteLine(builder.ToString());

            Func<string> helloFuncExpressionBody = () => "Hello from a func!";
            Console.WriteLine(helloFuncExpressionBody());
        }
    }
}