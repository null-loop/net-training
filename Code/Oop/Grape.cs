namespace Oop
{
    public class Grape : IFood
    {
        public int FoodValue => 1;
        public FoodGroup FoodGroup => FoodGroup.Fruit;
        public override string ToString() => "Grape";
    }
}