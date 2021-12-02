
using AlgorithmsCSharp.Collections.PriorityQueue;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTests.Collections.PriorityQueue
{

    public class BinaryHeapMaxPQTests
    {
        [Test]
        public void BinaryHeapMaxPQTest()
        {
            TestHelper.DoMaxPQTests((capacity) => new BinaryHeapMaxPQ<IComparable>(capacity));
        }
    }
}