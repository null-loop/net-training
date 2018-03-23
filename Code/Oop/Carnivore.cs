namespace Oop
{
    public abstract class Carnivore : Animal
    {
        public override bool CanEat(IFood food)
        {
            if (food.FoodGroup == FoodGroup.Meat) return true;
            return false;
        }
    }
}