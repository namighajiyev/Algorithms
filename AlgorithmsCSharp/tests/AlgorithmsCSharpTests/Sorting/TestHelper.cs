using AlgorithmsCSharp.Sorting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTests.Sorting
{
    public class TestHelper
    {

        private static bool IsSorted(IComparable[] items, bool isAsc = true)
        {
            var length = items.Length - 1;
            for (int i = 0; i < length; i++)
            {
                var item1 = items[i];
                var item2 = items[i + 1];
                var result = item1.CompareTo(item2);
                var isSorted = (isAsc && result <= 0) || (!isAsc && result >= 0);
                if (!isSorted) { return false; }
            }
            return true;
        }

        public static bool IsSortedAsc(IComparable[] items)
        {
            return IsSorted(items);
        }

        public static bool IsSortedDesc(IComparable[] items)
        {
            return IsSorted(items, false);
        }

        public static void DoTests(IComparable[] arr, ISortAlgorithm sorter)
        {
            var isSorted = TestHelper.IsSortedAsc(arr);
            Assert.IsFalse(isSorted);

            isSorted = TestHelper.IsSortedDesc(arr);
            Assert.IsFalse(isSorted);

            sorter.Sort(arr);
            isSorted = TestHelper.IsSortedAsc(arr);
            Assert.IsTrue(isSorted);

            arr = arr.Reverse().ToArray();
            isSorted = TestHelper.IsSortedDesc(arr);
            Assert.IsTrue(isSorted);
        }
    }
}
