using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsCSharp.Geometric
{
    public class Point
    {
        public readonly double x;
        public readonly double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public class PointEqualityComparer : IEqualityComparer<Point>
        {
            public bool Equals(Point p1, Point p2)
            {
                return p1.x == p2.x && p1.y == p2.y;
            }

            public int GetHashCode(Point obj)
            {
                return ((int)obj.x << 2) ^ (int)obj.y;
            }
        }

    }
}
