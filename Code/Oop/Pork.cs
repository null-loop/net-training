namespace Oop
{
    public class Pork : IFood
    {
        public int FoodValue => 35;
        public FoodGroup FoodGroup => FoodGroup.Meat;
        public override string ToString() => "Pork";
    }
}