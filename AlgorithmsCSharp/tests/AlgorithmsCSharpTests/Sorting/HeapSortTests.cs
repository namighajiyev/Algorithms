
using AlgorithmsCSharp.Sorting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTests.Sorting
{

    public class HeapSortTests
    {
        [Test]
        public void HeapSortTest()
        {
            var arr = TestData.NewUnsortedArray;
            var sorter = new HeapSort();
            TestHelper.DoTests(arr, sorter);
        }
    }
}