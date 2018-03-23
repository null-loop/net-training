namespace Oop
{
    public class Human : Omnivore, IMakeSounds
    {
        public override string ToString() => "Human";
        public string Contentment() => "Ahhhhhh that's better";
        public string Surprise() => "DUDE! WTF!?";
    }
}