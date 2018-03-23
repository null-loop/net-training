namespace Oop
{
    public class Dog : IMakeSounds
    {
        public string Surprise()
        {
            return "Yelp";
        }

        public string Contentment()
        {
            return "Bark";
        }
    }
}