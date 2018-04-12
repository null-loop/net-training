using FluentAssertions;
using Oop;
using Xunit;

namespace UnitTesting
{

    public class AnimalTests
    {
        private class MyAnimal : Animal
        {
            public override bool CanEat(IFood food)
            {
                return true;
            }
        }

        private class MyFood : IFood
        {
            public int FoodValue { get; set; }
            public FoodGroup FoodGroup { get; set; }
        }

        [Fact]
        public void Animal_Eating_Food_Receives_The_FoodValue_To_Its_FoodLevel()
        {
            var myAnimal = new MyAnimal();
            myAnimal.FoodLevel.Should().Be(0);

            myAnimal.Eat(new MyFood
            {
                FoodGroup = FoodGroup.Meat,
                FoodValue = 5
            });

            myAnimal.FoodLevel.Should().Be(5);
        }

        [Fact]
        public void Animal_Eating_2_Lots_Of_Food_Receives_The_Cumulative_FoodValue_To_Its_FoodLevel()
        {
            var myAnimal = new MyAnimal();
            myAnimal.FoodLevel.Should().Be(0);

            myAnimal.Eat(new MyFood
            {
                FoodGroup = FoodGroup.Meat,
                FoodValue = 5
            });

            myAnimal.Eat(new MyFood
            {
                FoodGroup = FoodGroup.Meat,
                FoodValue = 3
            });

            myAnimal.FoodLevel.Should().Be(8);
        }

        [Fact]
        public void Animal_Eating_Food_Increases_Its_FoodValue()
        {
            var myAnimal = new MyAnimal();
            myAnimal.FoodValue.Should().Be(0);

            myAnimal.Eat(new MyFood
            {
                FoodGroup = FoodGroup.Meat,
                FoodValue = 5
            });

            myAnimal.FoodValue.Should().Be(5);
        }
    }
}