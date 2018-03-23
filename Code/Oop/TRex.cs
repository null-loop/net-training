namespace Oop
{
    public class TRex : Carnivore, IMakeSounds
    {
        public override string ToString() => "TRex";
        public string Contentment() => "ROAR!";
        public string Surprise() => "ROAR!";
    }
}