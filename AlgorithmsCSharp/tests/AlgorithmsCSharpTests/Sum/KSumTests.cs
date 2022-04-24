using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlgorithmsCSharp.src.AlgorithmsCSharp.Sum;
using NUnit.Framework;

namespace AlgorithmsCSharp.tests.AlgorithmsCSharpTests.Sum;

public class KSumTests
{
    [Test]
    public void KSumTest()
    {
        var fourSum = new KSum();
        var result = fourSum.CalculateKSum(new int[] { 2, 2, 2, 2, 2 }, 8, 0,4);
        result = fourSum.CalculateKSum(new int[] { -3, -1, 0, 2, 4, 5 }, 0, 0, 4);
        result = fourSum.CalculateKSum(new int[] { -3, -2, -1, 0, 0, 1, 2, 3 }, 0, 0, 4);
        result = fourSum.CalculateKSum(new int[] { 0, 0, 0, 0 }, 0, 0, 4);
    }
}
