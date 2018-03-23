namespace Oop
{
    public abstract class Animal : IEat, IFood
    {
        public int FoodLevel { get; private set; }

        public FoodGroup FoodGroup => FoodGroup.Meat;

        public void Eat(IFood food)
        {
            if (!CanEat(food))
            {
                throw new InvalidFoodException($"As a {ToString()} I cannot eat {food}");
            }
            FoodLevel += food.FoodValue;
        }

        public abstract bool CanEat(IFood food);

        public int FoodValue => FoodLevel;
    }
}