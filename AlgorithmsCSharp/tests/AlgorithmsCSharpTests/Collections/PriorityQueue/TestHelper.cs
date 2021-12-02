using AlgorithmsCSharp.Collections.PriorityQueue;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTests.Collections.PriorityQueue
{
    public static class TestHelper
    {
        public static void DoMaxPQTests(Func<int, IMaxPriorityQueue<IComparable>> pqCreator)
        {
            var arr = TestData.NewUnsortedArray;
            var pq = pqCreator(arr.Length);
            foreach (var item in arr)
            {
                pq.Insert(item);
            }

            new AlgorithmsCSharp.Sorting.QuickSort().Sort(arr);
            arr = arr.Reverse().ToArray();

            foreach (var item in arr)
            {
                var deleted = pq.DeleteMax();
                Assert.AreEqual(item, deleted);
            }

        }

        public static void DoMinPQTests(Func<int, IMinPriorityQueue<IComparable>> pqCreator)
        {
            var arr = TestData.NewUnsortedArray;
            var pq = pqCreator(arr.Length);
            foreach (var item in arr)
            {
                pq.Insert(item);
            }

            new AlgorithmsCSharp.Sorting.QuickSort().Sort(arr);
            // arr = arr.Reverse().ToArray();

            foreach (var item in arr)
            {
                var deleted = pq.DeleteMin();
                Assert.AreEqual(item, deleted);
            }

        }
    }
}
