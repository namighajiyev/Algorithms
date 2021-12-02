
using AlgorithmsCSharp.Sorting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTests.Sorting
{

    public class QuickSelectTests
    {
        [Test]
        public void QuickSelectTest()
        {
            var arrOrigin = TestData.NewUnsortedArray;
            var arr = TestData.NewUnsortedArray;
            Assert.IsTrue(arr.SequenceEqual(arrOrigin));
            int k = new Random().Next(arr.Length);
            var selected = new QuickSelect().Select(arr, k);
            new QuickSort().Sort(arrOrigin);
            Assert.AreEqual(selected, arrOrigin[k]);
        }
    }
}