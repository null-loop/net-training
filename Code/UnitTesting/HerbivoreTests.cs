using System;
using FluentAssertions;
using Oop;
using Xunit;

namespace UnitTesting
{
    public class HerbivoreTests
    {
        private class MyHerbivore : Herbivore
        {
            public override string ToString()
            {
                return "MyHerbivore";
            }
        }

        [Fact]
        public void Herbivore_Can_Eat_Fruit()
        {
            var myHerbivore = new MyHerbivore();
            myHerbivore.CanEat(new Banana()).Should().BeTrue();
        }

        [Fact]
        public void Herbivore_Can_Eat_Vegetable()
        {
            var myHerbivore = new MyHerbivore();
            myHerbivore.CanEat(new Carrot()).Should().BeTrue();
        }

        [Fact]
        public void Herbivore_Cannot_Eat_Meat()
        {
            var myHerbivore = new MyHerbivore();
            myHerbivore.CanEat(new Pork()).Should().BeFalse();
        }

        [Fact]
        public void Herbivore_Throws_InvalidFoodException_When_Eating_Meat()
        {
            var myCarnivore = new MyHerbivore();
            Action eatingFruitAction = () => myCarnivore.Eat(new Pork());
            eatingFruitAction.Should()
                .Throw<InvalidFoodException>()
                .WithMessage("As a MyHerbivore I cannot eat Pork");
        }
    }
}