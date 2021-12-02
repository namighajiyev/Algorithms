using AlgorithmsCSharp.DynamicConnectivity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTests.DynamicConnectivity
{
    public class DynamicConnectivityTestRuner
    {

        public static void RunTests(IDynamicConnectivityAlgorithm dc)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    var isConnected = dc.IsConnected(i, j);
                    if (i == j)
                    {
                        Assert.IsTrue(isConnected);
                    }
                    else
                    {
                        Assert.IsFalse(isConnected);
                    }

                }
            }

            dc.Connect(4, 3);
            Assert.IsTrue(dc.IsConnected(4, 3));
            Assert.IsTrue(dc.IsConnected(3, 4));
            Assert.IsFalse(dc.IsConnected(0, 4));

            dc.Connect(3, 8);
            Assert.IsTrue(dc.IsConnected(3, 8));
            Assert.IsTrue(dc.IsConnected(8, 3));
            Assert.IsTrue(dc.IsConnected(8, 4));
            Assert.IsTrue(dc.IsConnected(4, 8));
            Assert.IsFalse(dc.IsConnected(0, 4));
            Assert.IsFalse(dc.IsConnected(1, 2));

            dc.Connect(6, 5);
            Assert.IsTrue(dc.IsConnected(6, 5));
            Assert.IsTrue(dc.IsConnected(5, 6));
            Assert.IsTrue(dc.IsConnected(3, 8));
            Assert.IsTrue(dc.IsConnected(8, 3));
            Assert.IsTrue(dc.IsConnected(8, 4));
            Assert.IsTrue(dc.IsConnected(4, 8));
            Assert.IsFalse(dc.IsConnected(0, 4));
            Assert.IsFalse(dc.IsConnected(1, 2));
            Assert.IsFalse(dc.IsConnected(7, 8));

            dc.Connect(9, 4);
            Assert.IsTrue(dc.IsConnected(9, 4));
            Assert.IsTrue(dc.IsConnected(4, 9));
            Assert.IsTrue(dc.IsConnected(6, 5));
            Assert.IsTrue(dc.IsConnected(5, 6));
            Assert.IsTrue(dc.IsConnected(3, 8));
            Assert.IsTrue(dc.IsConnected(8, 3));
            Assert.IsTrue(dc.IsConnected(8, 4));
            Assert.IsTrue(dc.IsConnected(4, 8));
            Assert.IsFalse(dc.IsConnected(0, 4));
            Assert.IsFalse(dc.IsConnected(1, 2));
            Assert.IsFalse(dc.IsConnected(7, 8));

            dc.Connect(2, 1);
            Assert.IsTrue(dc.IsConnected(2, 1));
            Assert.IsTrue(dc.IsConnected(1, 2));
            Assert.IsTrue(dc.IsConnected(9, 4));
            Assert.IsTrue(dc.IsConnected(4, 9));
            Assert.IsTrue(dc.IsConnected(6, 5));
            Assert.IsTrue(dc.IsConnected(5, 6));
            Assert.IsTrue(dc.IsConnected(3, 8));
            Assert.IsTrue(dc.IsConnected(8, 3));
            Assert.IsTrue(dc.IsConnected(8, 4));
            Assert.IsTrue(dc.IsConnected(8, 9));
            Assert.IsTrue(dc.IsConnected(4, 8));
            Assert.IsFalse(dc.IsConnected(0, 4));
            Assert.IsFalse(dc.IsConnected(6, 2));
            Assert.IsFalse(dc.IsConnected(7, 8));
            Assert.IsFalse(dc.IsConnected(5, 4));

            dc.Connect(5, 0);
            Assert.IsTrue(dc.IsConnected(5, 0));
            Assert.IsTrue(dc.IsConnected(0, 5));
            Assert.IsTrue(dc.IsConnected(2, 1));
            Assert.IsTrue(dc.IsConnected(1, 2));
            Assert.IsTrue(dc.IsConnected(9, 4));
            Assert.IsTrue(dc.IsConnected(4, 9));
            Assert.IsTrue(dc.IsConnected(6, 5));
            Assert.IsTrue(dc.IsConnected(5, 6));
            Assert.IsTrue(dc.IsConnected(3, 8));
            Assert.IsTrue(dc.IsConnected(8, 3));
            Assert.IsTrue(dc.IsConnected(8, 4));
            Assert.IsTrue(dc.IsConnected(8, 9));
            Assert.IsTrue(dc.IsConnected(4, 8));
            Assert.IsTrue(dc.IsConnected(6, 0));
            Assert.IsTrue(dc.IsConnected(0, 6));
            Assert.IsFalse(dc.IsConnected(0, 4));
            Assert.IsFalse(dc.IsConnected(6, 2));
            Assert.IsFalse(dc.IsConnected(7, 8));
            Assert.IsFalse(dc.IsConnected(5, 4));
            Assert.IsFalse(dc.IsConnected(7, 0));


            dc.Connect(7, 2);
            Assert.IsTrue(dc.IsConnected(7, 2));
            Assert.IsTrue(dc.IsConnected(2, 7));
            Assert.IsTrue(dc.IsConnected(5, 0));
            Assert.IsTrue(dc.IsConnected(0, 5));
            Assert.IsTrue(dc.IsConnected(2, 1));
            Assert.IsTrue(dc.IsConnected(1, 2));
            Assert.IsTrue(dc.IsConnected(9, 4));
            Assert.IsTrue(dc.IsConnected(4, 9));
            Assert.IsTrue(dc.IsConnected(6, 5));
            Assert.IsTrue(dc.IsConnected(5, 6));
            Assert.IsTrue(dc.IsConnected(3, 8));
            Assert.IsTrue(dc.IsConnected(8, 3));
            Assert.IsTrue(dc.IsConnected(8, 4));
            Assert.IsTrue(dc.IsConnected(8, 9));
            Assert.IsTrue(dc.IsConnected(4, 8));
            Assert.IsTrue(dc.IsConnected(6, 0));
            Assert.IsTrue(dc.IsConnected(0, 6));
            Assert.IsTrue(dc.IsConnected(1, 7));
            Assert.IsTrue(dc.IsConnected(7, 1));
            Assert.IsFalse(dc.IsConnected(0, 4));
            Assert.IsFalse(dc.IsConnected(6, 2));
            Assert.IsFalse(dc.IsConnected(7, 8));
            Assert.IsFalse(dc.IsConnected(5, 4));
            Assert.IsFalse(dc.IsConnected(7, 0));


            dc.Connect(6, 1);
            Assert.IsTrue(dc.IsConnected(6, 1));
            Assert.IsTrue(dc.IsConnected(1, 6));
            Assert.IsTrue(dc.IsConnected(7, 2));
            Assert.IsTrue(dc.IsConnected(2, 7));
            Assert.IsTrue(dc.IsConnected(5, 0));
            Assert.IsTrue(dc.IsConnected(0, 5));
            Assert.IsTrue(dc.IsConnected(2, 1));
            Assert.IsTrue(dc.IsConnected(1, 2));
            Assert.IsTrue(dc.IsConnected(9, 4));
            Assert.IsTrue(dc.IsConnected(4, 9));
            Assert.IsTrue(dc.IsConnected(6, 5));
            Assert.IsTrue(dc.IsConnected(5, 6));
            Assert.IsTrue(dc.IsConnected(3, 8));
            Assert.IsTrue(dc.IsConnected(8, 3));
            Assert.IsTrue(dc.IsConnected(8, 4));
            Assert.IsTrue(dc.IsConnected(8, 9));
            Assert.IsTrue(dc.IsConnected(4, 8));
            Assert.IsTrue(dc.IsConnected(6, 0));
            Assert.IsTrue(dc.IsConnected(0, 6));
            Assert.IsTrue(dc.IsConnected(1, 7));
            Assert.IsTrue(dc.IsConnected(7, 1));
            Assert.IsTrue(dc.IsConnected(6, 2));
            Assert.IsTrue(dc.IsConnected(7, 0));
            Assert.IsFalse(dc.IsConnected(0, 4));
            Assert.IsFalse(dc.IsConnected(7, 8));
            Assert.IsFalse(dc.IsConnected(5, 4));
            Assert.IsFalse(dc.IsConnected(3, 2));

            dc.Connect(7, 3);
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Assert.IsTrue(dc.IsConnected(i, j));
                }
            }
        }
    }
}
