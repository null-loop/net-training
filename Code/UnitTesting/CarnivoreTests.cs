using System;
using FluentAssertions;
using Oop;
using Xunit;

namespace UnitTesting
{
    public class CarnivoreTests
    {
        private class MyCarnivore : Carnivore
        {
            public override string ToString()
            {
                return "MyCarnivore";
            }
        }

        [Fact]
        public void Carnivore_Can_Eat_Meat()
        {
            var myCarnivore = new MyCarnivore();
            myCarnivore.CanEat(new Pork()).Should().BeTrue();
        }

        [Fact]
        public void Carnivore_Cannot_Eat_Fruit()
        {
            var myCarnivore = new MyCarnivore();
            myCarnivore.CanEat(new Banana()).Should().BeFalse();
        }

        [Fact]
        public void Carnivore_Cannot_Eat_Vegetable()
        {
            var myCarnivore = new MyCarnivore();
            myCarnivore.CanEat(new Carrot()).Should().BeFalse();
        }

        [Fact]
        public void Carnivore_Throws_InvalidFoodException_When_Eating_Fruit()
        {
            var myCarnivore = new MyCarnivore();
            Action eatingFruitAction = () => myCarnivore.Eat(new Banana());
            eatingFruitAction.Should()
                .Throw<InvalidFoodException>()
                .WithMessage("As a MyCarnivore I cannot eat Banana");
        }

        [Fact]
        public void Carnivore_Throws_InvalidFoodException_When_Eating_Vegetable()
        {
            var myCarnivore = new MyCarnivore();
            Action eatingFruitAction = () => myCarnivore.Eat(new Carrot());
            eatingFruitAction.Should()
                .Throw<InvalidFoodException>()
                .WithMessage("As a MyCarnivore I cannot eat Carrot");
        }
    }
}