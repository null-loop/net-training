using System;
using SharedCode;

namespace Exceptions
{
    public static class Exceptions
    {
        public static void Demonstrate()
        {
            DemonstrateUnhandledException();
            DemonstrateCatchingException();
            DemonstrateCatchingAndThrowingException();
            DemonstrateCatchingWrappingAndThrowingException();
            DemonstrateCorrectWayToRethrowException();
            DemonstrateFinallyBlock();
        }

        private static void DemonstrateFinallyBlock()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateFinallyBlock));

            Console.WriteLine("I'm gonna error...");
            try
            {
                BreakingMethod();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("I still ran!");
            }

            Console.WriteLine();
            Console.WriteLine("I'm not gonna error...");
            try
            {
                var i = 100;
                var x = 10;
                var y = i / x;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("I still ran!");
            }
        }

        private static void DemonstrateCorrectWayToRethrowException()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateCatchingException));

            Console.WriteLine("The wrong way...");

            try
            {
                try
                {
                    BreakingMethod();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    // WRONG! - we'll lose the stack trace from here
                    throw e;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            Console.WriteLine("The right way...");

            try
            {
                try
                {
                    BreakingMethod();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    // RIGHT! - we'll preserve the stack trace from here
                    throw;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private static void BreakingMethod()
        {
            throw new DumbProgrammerException("DUH.....");
        }

        private static void DemonstrateCatchingWrappingAndThrowingException()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateCatchingException));

            try
            {
                var x = 0;
                var i = 100 / x;
            }
            catch (Exception e)
            {
                throw new DumbProgrammerException("OOOPS! - Dumb programmer has messed up", e);
            }
        }

        private static void DemonstrateCatchingAndThrowingException()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateCatchingException));

            try
            {
                var x = 0;
                var i = 100 / x;
            }
            catch (Exception e)
            {
                Console.WriteLine($"OOPS! - Someone done something bad.... {e.Message} - but I cannot handle this");
                throw;
            }
        }

        private static void DemonstrateCatchingException()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateCatchingException));

            try
            {
                var x = 0;
                var i = 100 / x;
            }
            catch (Exception e)
            {
                Console.WriteLine($"OOPS! - Someone done something bad.... {e.Message} - but I can handle this");
            }
        }

        private static void DemonstrateUnhandledException()
        {
            ConsoleHelper.WriteHeading(nameof(DemonstrateUnhandledException));

            // divide by 0 - it really doesn't like this
            var x = 0;
            var i = 100 / x;
        }
    }
}