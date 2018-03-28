using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public static class LargestInteger
    {
        public static int FindLargest(IEnumerable<int> integers)
        {
            return integers.Max();
        }
    }
}
