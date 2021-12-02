
using AlgorithmsCSharp.Sorting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTests.Sorting
{

    public class SelectionSortTests
    {
        [Test]
        public void SelectionSortTest()
        {
            var arr = TestData.NewUnsortedArray;
            var sorter = new SelectionSort();
            TestHelper.DoTests(arr, sorter);
        }

    }
}