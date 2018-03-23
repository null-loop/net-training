using System;
using System.Collections.Generic;

namespace Oop
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> WhereEnumerable<T>(this IEnumerable<T> sequence, Func<T, bool> predicate)
        {
            var results = new List<T>();
            using (var enumerator = sequence.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (predicate(enumerator.Current)) results.Add(enumerator.Current);
                }
            }
            return results;
        }
    }
}