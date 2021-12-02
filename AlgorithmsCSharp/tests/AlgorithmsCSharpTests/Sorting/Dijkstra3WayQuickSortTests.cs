
using AlgorithmsCSharp.Sorting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTests.Sorting
{

    public class Dijkstra3WayQuickSortTests
    {
        [Test]
        public void Dijkstra3WayQuickSortTest()
        {
            var arr = TestData.NewUnsortedArray;
            var sorter = new Dijkstra3WayQuickSort();
            TestHelper.DoTests(arr, sorter);
        }
    }
}