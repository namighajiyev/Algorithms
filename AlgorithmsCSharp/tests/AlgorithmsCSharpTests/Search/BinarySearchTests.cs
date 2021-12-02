
using AlgorithmsCSharp.Search;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTests.Search
{

    public class BinarySearchTests
    {
        [Test]
        public void BinarySearchTest()
        {
            var key = 33;
            var items = new int[] { 6, 13, 14, 25, 33, 43, 51, 53, 64, 72, 84, 93, 95, 96, 97 };
            var bs = new BinarySearch();
            var foundIndex = bs.Search(items, key);
            Assert.AreEqual(foundIndex, 4);

        }
    }
}