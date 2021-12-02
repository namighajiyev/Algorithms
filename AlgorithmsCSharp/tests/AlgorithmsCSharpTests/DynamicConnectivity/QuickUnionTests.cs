
using AlgorithmsCSharp.DynamicConnectivity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTests.DynamicConnectivity
{

    public class QuickUnionTests
    {

        [Test]
        public void QuickUnionTest()
        {
            var dc = new QuickUnion(10);
            DynamicConnectivityTestRuner.RunTests(dc);
        }


    }
}