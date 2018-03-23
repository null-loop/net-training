namespace Oop
{
    public class Squirrel : Herbivore, IMakeSounds
    {
        public override string ToString() => "Squirrel";
        public string Contentment() => "Squeek!";
        public string Surprise() => "SQUEEK!";
    }
}