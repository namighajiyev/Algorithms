
using AlgorithmsCSharp.Sorting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTests.Sorting
{

    public class BottomUpMergeSortTests
    {
        [Test]
        public void BottomUpMergeSortTest()
        {
            var arr = TestData.NewUnsortedArray;
            var sorter = new BottomUpMergeSort();
            TestHelper.DoTests(arr, sorter);
        }
    }
}