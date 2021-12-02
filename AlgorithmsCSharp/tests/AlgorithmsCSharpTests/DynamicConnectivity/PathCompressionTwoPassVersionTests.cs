
using AlgorithmsCSharp.DynamicConnectivity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTests.DynamicConnectivity
{

    public class PathCompressionTwoPassVersionTests
    {
        [Test]
        public void PathCompressionTwoPassVersionTest()
        {
            var dc = new PathCompressionTwoPassVersion(10);
            DynamicConnectivityTestRuner.RunTests(dc);
        }


    }
}