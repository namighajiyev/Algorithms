
using AlgorithmsCSharp.Collections.PriorityQueue;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTests.Collections.PriorityQueue
{

    public class UnorderedMaxPQTests
    {
        [Test]
        public void UnorderedMaxPQTest()
        {
            TestHelper.DoMaxPQTests((capacity) => new UnorderedMaxPQ<IComparable>(capacity));
        }
    }
}