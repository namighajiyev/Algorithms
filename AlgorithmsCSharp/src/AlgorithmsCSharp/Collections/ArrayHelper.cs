using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsCSharp.Collections
{
    public static class ArrayHelper
    {
        public static void Swap(object[] items, int index1, int index2)
        {
            var swap = items[index1];
            items[index1] = items[index2];
            items[index2] = swap;
        }

        public static bool IsLess(IComparable comparable1, IComparable comparable2)
        {
            return comparable1.CompareTo(comparable2) < 0;
        }

        public static bool IsGreater(IComparable comparable1, IComparable comparable2)
        {
            return comparable1.CompareTo(comparable2) > 0;
        }
    }
}
