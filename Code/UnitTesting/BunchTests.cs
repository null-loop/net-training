using System;
using FluentAssertions;
using Oop;
using Xunit;

namespace UnitTesting
{
    public class BunchTests
    {
        private class MyFood : IFood
        {
            public int FoodValue { get; set; }
            public FoodGroup FoodGroup { get; set; }
        }

        [Fact]
        public void Bunch_Has_Sum_Of_FoodValue()
        {
            var myFoodOne = new MyFood
            {
                FoodGroup = FoodGroup.Fruit,
                FoodValue = 10
            };

            var myFoodTwo = new MyFood
            {
                FoodGroup = FoodGroup.Fruit,
                FoodValue = 15
            };

            var bunch = new Bunch<MyFood>(new[] {myFoodOne, myFoodTwo});

            bunch.FoodValue.Should().Be(25);
        }

        [Fact]
        public void Bunch_Has_FoodGroup_Of_First_Member()
        {
            var myFoodOne = new MyFood
            {
                FoodGroup = FoodGroup.Fruit,
                FoodValue = 10
            };

            var myFoodTwo = new MyFood
            {
                FoodGroup = FoodGroup.Fruit,
                FoodValue = 15
            };

            var bunch = new Bunch<MyFood>(new[] { myFoodOne, myFoodTwo });

            bunch.FoodGroup.Should().Be(FoodGroup.Fruit);
        }

        [Fact]
        public void Bunch_Constructor_Throws_ArgumentException_When_Given_Different_FoodGroups()
        {
            var myFoodOne = new MyFood
            {
                FoodGroup = FoodGroup.Fruit,
                FoodValue = 10
            };

            var myFoodTwo = new MyFood
            {
                FoodGroup = FoodGroup.Meat,
                FoodValue = 15
            };

            Action createAction = () => new Bunch<MyFood>(new[] {myFoodOne, myFoodTwo});

            createAction.Should().Throw<ArgumentException>().WithMessage("Cannot add Meat to a bunch of Fruit");
        }
    }
}