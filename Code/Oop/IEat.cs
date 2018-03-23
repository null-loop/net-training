namespace Oop
{
    public interface IEat
    {
        bool CanEat(IFood food);
        void Eat(IFood food);
        int FoodLevel { get; }
    }
}