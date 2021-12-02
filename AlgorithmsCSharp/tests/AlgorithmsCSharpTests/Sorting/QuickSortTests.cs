
using AlgorithmsCSharp.Sorting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTests.Sorting
{

    public class QuickSortTests
    {
        [Test]
        public void QuickSortTest()
        {
            var arr = TestData.NewUnsortedArray;
            var sorter = new QuickSort();
            TestHelper.DoTests(arr, sorter);
        }
    }
}