
using AlgorithmsCSharp.DynamicConnectivity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTests.DynamicConnectivity
{

    public class PathCompressionOnePassVersionTests
    {
        [Test]
        public void PathCompressionOnePassVersionTest()
        {
            var dc = new PathCompressionOnePassVersion(10);
            DynamicConnectivityTestRuner.RunTests(dc);
        }
    }
}