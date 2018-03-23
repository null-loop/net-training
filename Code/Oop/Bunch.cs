using System.Collections.Generic;
using System.Linq;

namespace Oop
{
    public class Bunch<T> : IFood where T : IFood
    {
        private readonly IEnumerable<T> _bunchContents;

        public Bunch(IEnumerable<T> bunchContents)
        {
            _bunchContents = bunchContents;
        }

        public int FoodValue => _bunchContents.Sum(b => b.FoodValue);
        public FoodGroup FoodGroup => _bunchContents.Any() ? _bunchContents.First().FoodGroup : FoodGroup.Unknown;

        public override string ToString() => $"Bunch of {typeof(T).Name}s";
    }
}