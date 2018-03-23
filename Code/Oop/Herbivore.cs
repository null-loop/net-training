namespace Oop
{
    public abstract class Herbivore : Animal
    {
        public override bool CanEat(IFood food)
        {
            if (food.FoodGroup == FoodGroup.Fruit || food.FoodGroup == FoodGroup.Vegetable) return true;
            return false;
        }
    }
}