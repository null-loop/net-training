namespace Oop
{
    public class Beef : IFood
    {
        public int FoodValue => 50;
        public FoodGroup FoodGroup => FoodGroup.Meat;

        public override string ToString() => "Beef";
    }
}