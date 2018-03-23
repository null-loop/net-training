using System;
using System.Collections.Generic;

namespace Linq
{
    public static class MyLinqExtensions
    {
        public static IEnumerable<TInput> MyWhere<TInput>(this IEnumerable<TInput> sequence, Func<TInput, bool> predicate)
        {
            foreach (var element in sequence)
                if (predicate(element)) yield return element;
        }

        public static IEnumerable<TOutput> MySelect<TInput, TOutput>(this IEnumerable<TInput> sequence, Func<TInput, TOutput> projector)
        {
            foreach (var element in sequence)
                yield return projector(element);
        }

        public static int MyCount<TInput>(this IEnumerable<TInput> sequence)
        {
            return sequence.MyCount(e => true);
        }

        public static int MyCount<TInput>(this IEnumerable<TInput> sequence, Func<TInput, bool> predicate)
        {
            var count = 0;
            foreach (var element in sequence)
            {
                if (predicate(element)) count++;
            }
            return count;
        }
    }
}