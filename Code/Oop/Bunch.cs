using System;
using System.Collections.Generic;
using System.Linq;

namespace Oop
{
    public class Bunch<T> : IFood where T : IFood
    {
        private readonly IEnumerable<T> _bunchContents;

        public Bunch(IEnumerable<T> bunchContents)
        {
            var bunchArray = bunchContents.ToArray();
            EnforceAllFoodGroupsAreOfTheSameValue(bunchArray);

            _bunchContents = bunchArray;
        }

        private static void EnforceAllFoodGroupsAreOfTheSameValue(T[] bunchArray)
        {
            if (bunchArray.Any())
            {
                var firstFoodGroup = bunchArray.First().FoodGroup;
                var firstDifferentFoodGroup = bunchArray.FirstOrDefault(f => f.FoodGroup != firstFoodGroup);
                if (firstDifferentFoodGroup != null)
                {
                    throw new ArgumentException(
                        $"Cannot add {firstDifferentFoodGroup.FoodGroup} to a bunch of {firstFoodGroup}");
                }
            }
        }

        public int FoodValue => _bunchContents.Sum(b => b.FoodValue);
        public FoodGroup FoodGroup => _bunchContents.Any() ? _bunchContents.First().FoodGroup : FoodGroup.Unknown;

        public override string ToString() => $"Bunch of {typeof(T).Name}s";
    }
}