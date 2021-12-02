
using AlgorithmsCSharp.DynamicConnectivity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTests.DynamicConnectivity
{

    public class QuickFindTests
    {


        [Test]
        public void QuickFindTest()
        {
            var dc = new QuickFind(10);
            DynamicConnectivityTestRuner.RunTests(dc);
        }

    }
}