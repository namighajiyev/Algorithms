
using AlgorithmsCSharp.Collections.PriorityQueue;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTests.Collections.PriorityQueue
{

    public class BinaryHeapMinPQTests
    {
        [Test]
        public void BinaryHeapMinPQTest()
        {
            TestHelper.DoMinPQTests((capacity) => new BinaryHeapMinPQ<IComparable>(capacity));
        }

    }
}