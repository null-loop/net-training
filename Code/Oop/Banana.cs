namespace Oop
{
    public class Banana : IFood
    {
        public int FoodValue => 10;
        public FoodGroup FoodGroup => FoodGroup.Fruit;
        public override string ToString() => "Banana";
    }
}