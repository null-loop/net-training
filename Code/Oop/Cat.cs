namespace Oop
{
    public class Cat : IMakeSounds
    {
        public string Surprise()
        {
            return "MEOW!";
        }

        public string Contentment()
        {
            return "Purr";
        }
    }
}