
using AlgorithmsCSharp.Mathematical;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTests.Mathematical
{

    public class FYShuffleTests
    {
        [Test]
        public void FYShuffleTest()
        {

            var arr = TestData.NewUnsortedArray;
            var arrOriginal = TestData.NewUnsortedArray;
            Assert.IsTrue(arr.SequenceEqual(arrOriginal));
            var shuffler = new FYShuffle();
            shuffler.Shuffle(arr);
            Assert.IsFalse(arr.SequenceEqual(arrOriginal));
        }
    }
}