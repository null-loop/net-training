using System;
using SharedCode;

namespace ClassStructures
{
    internal static class Statics
    {
        public static void Demonstrate()
        {
            DemonstrateStaticMethods();
        }

        private static void DemonstrateStaticMethods()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateStaticMethods));

            Console.Write(U2.ListMembers());

            var members = U2.GetMembers();

            foreach (var member in members)
            {
                switch (member.FullName)
                {
                    case "Paul Hewson":
                        member.ChangeName("Bono");
                        break;
                    case "David Evans":
                        member.ChangeName("The Edge");
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(U2.ListMembers());
        }
    }
}