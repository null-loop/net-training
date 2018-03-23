namespace Oop
{
    public abstract class Omnivore : Animal
    {
        public override bool CanEat(IFood food)
        {
            return true;
        }
    }
}