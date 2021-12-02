
using AlgorithmsCSharp.Sorting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTests.Sorting
{

    public class MergeSortTests
    {
        [Test]
        public void MergeSortTest()
        {
            var arr = TestData.NewUnsortedArray;
            var sorter = new MergeSort();
            TestHelper.DoTests(arr, sorter);
        }
    }
}