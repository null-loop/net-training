namespace Oop
{
    public class Carrot : IFood
    {
        public int FoodValue => 6;
        public FoodGroup FoodGroup => FoodGroup.Vegetable;
        public override string ToString() => "Carrot";
    }
}