
using AlgorithmsCSharp.DynamicConnectivity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTests.DynamicConnectivity
{

    public class WeightedQuickUnionTests
    {
        [Test]
        public void WeightedQuickUnionTest()
        {
            var dc = new WeightedQuickUnion(10);
            DynamicConnectivityTestRuner.RunTests(dc);
        }


    }
}