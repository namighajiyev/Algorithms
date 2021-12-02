using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsCSharp.Geometric
{
    public class GrahamScanConvexHull
    {
        public readonly IComparer<Point> Y_ORDER_COMPARER = new YOrderComparer();
        public readonly Func<Point, IComparer<Point>> BY_POLAR_ORDER_COMPARER_FACTORY = (minYPoint) => new PolarOrderComparer(minYPoint);

        public enum ClockwiseDirection
        {
            Clockwise = -1,
            CounterClockwise = 1,
            Collinear = 0
        }

        public static ClockwiseDirection GetClockwiseDirection(Point a, Point b, Point c)
        {
            double area = (b.x - a.x) * (c.y - a.y) - (b.y - a.y) * (c.x - a.x);

            if (area < 0)
            {
                return ClockwiseDirection.Clockwise;
            }
            else if (area > 0)
            {
                return ClockwiseDirection.CounterClockwise;
            }
            else
            {
                return ClockwiseDirection.Collinear;
            }
        }

        public Point[] FindConvexHull(Point[] points)
        {
            var length = points.Length;
            var hull = new Stack<Point>();
            Point top;

            Array.Sort(points, Y_ORDER_COMPARER);
            Array.Sort(points, BY_POLAR_ORDER_COMPARER_FACTORY(points[0]));

            hull.Push(points[0]);
            hull.Push(points[1]);


            for (int i = 2; i < length; i++)
            {
                top = hull.Pop();
                while (GetClockwiseDirection(hull.Peek(), top, points[i]) != ClockwiseDirection.CounterClockwise)
                {
                    top = hull.Pop();
                }
                hull.Push(top);
                hull.Push(points[i]);
            }

            return hull.ToArray();
        }

        public class YOrderComparer : IComparer<Point>
        {
            public int Compare(Point p1, Point p2)
            {
                if (p1.y < p2.y) return -1;
                if (p1.y > p2.y) return +1;
                return 0;
            }
        }

        public class PolarOrderComparer : IComparer<Point>
        {
            private Point minYPoint;

            public PolarOrderComparer(Point minYPoint)
            {
                this.minYPoint = minYPoint;
            }

            public int Compare(Point point1, Point point2)
            {
                double dx1 = point1.x - minYPoint.x;
                double dy1 = point1.y - minYPoint.y;
                double dx2 = point2.x - minYPoint.x;
                double dy2 = point2.y - minYPoint.y;

                if (dy1 >= 0 && dy2 < 0) return -1;    // q1 above; q2 below
                else if (dy2 >= 0 && dy1 < 0) return +1;    // q1 below; q2 above
                else if (dy1 == 0 && dy2 == 0)
                {            // 3-collinear and horizontal
                    if (dx1 >= 0 && dx2 < 0) return -1;
                    else if (dx2 >= 0 && dx1 < 0) return +1;
                    else return 0;
                }
                else return -(int)GetClockwiseDirection(minYPoint, point1, point2);
            }
        }

    }
}
