using System;

namespace Generics
{
    public class FunctionExecutor
    {
        private readonly IOutputWriter _outputWriter;

        public FunctionExecutor(IOutputWriter outputWriter)
        {
            _outputWriter = outputWriter;
        }

        public void Execute(Func<string> function)
        {
            _outputWriter.WriteLine("FUNCTION-RESULT :: " + function());
        }
    }
}