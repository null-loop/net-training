namespace Generics
{
    public class Highlander
    {
        public Highlander(IOutputWriter outputWriter)
        {
            outputWriter.WriteLine("There can be only one!");
        }
    }
}