
using AlgorithmsCSharp.Sorting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTests.Sorting
{

    public class ShellSortTests
    {
        [Test]
        public void ShellSortTest()
        {
            var arr = TestData.NewUnsortedArray;
            var sorter = new ShellSort();
            TestHelper.DoTests(arr, sorter);
        }
    }
}