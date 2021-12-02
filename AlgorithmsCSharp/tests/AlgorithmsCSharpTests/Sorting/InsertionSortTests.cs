
using AlgorithmsCSharp.Sorting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTests.Sorting
{

    public class InsertionSortTests
    {
        [Test]
        public void InsertionSortTest()
        {
            var arr = TestData.NewUnsortedArray;
            var sorter = new InsertionSort();
            TestHelper.DoTests(arr, sorter);
        }
    }
}