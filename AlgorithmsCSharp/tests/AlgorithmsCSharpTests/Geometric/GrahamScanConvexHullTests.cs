
using AlgorithmsCSharp.Geometric;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTests.Geometric
{

    public class GrahamScanConvexHullTests
    {
        [Test]
        public void GrahamScanConvexHullTest()
        {
            var points = new Point[] {
                new Point (0, 3),
                new Point (1, 1),
                new Point (2, 2),
                new Point (4, 4),
                new Point (0, 0),
                new Point (1, 2),
                new Point (3, 1),
                new Point (3, 3)
                                    };

            var correctConvexHull = new Point[] {
                new Point (0, 3),
                new Point (4, 4),
                new Point (3, 1),
                new Point (0, 0)
                                    };

            var grahamScan = new GrahamScanConvexHull();
            var result = grahamScan.FindConvexHull(points);

            Assert.IsTrue(result.SequenceEqual(correctConvexHull, new Point.PointEqualityComparer()));

        }
    }
}