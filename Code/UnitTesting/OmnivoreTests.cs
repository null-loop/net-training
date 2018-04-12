using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Oop;
using Xunit;

namespace UnitTesting
{
    public class OmnivoreTests
    {
        private class MyOmnivore : Omnivore
        {
            
        }

        [Fact]
        public void Ominvore_Can_Eat_Meat()
        {
            var myOmnivore = new MyOmnivore();
            myOmnivore.CanEat(new Pork()).Should().BeTrue();
        }

        [Fact]
        public void Omnivore_Can_Eat_Fruit()
        {
            var myOmnivore = new MyOmnivore();
            myOmnivore.CanEat(new Banana()).Should().BeTrue();
        }

        [Fact]
        public void Omnivore_Can_Eat_Vegetable()
        {
            var myOmnivore = new MyOmnivore();
            myOmnivore.CanEat(new Carrot()).Should().BeTrue();
        }
    }
}
