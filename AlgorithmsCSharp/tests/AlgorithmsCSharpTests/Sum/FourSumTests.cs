using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlgorithmsCSharp.src.AlgorithmsCSharp.Sum;
using NUnit.Framework;

namespace AlgorithmsCSharp.tests.AlgorithmsCSharpTests.Sum;

public class FourSumTests
{
    [Test]
    public void FourSumTest()
    {
        var fourSum = new FourSum();
        var result = fourSum.CalculateFourSum(new int[] { 2, 2, 2, 2, 2 }, 8);
        result = fourSum.CalculateFourSum(new int[] { -3, -1, 0, 2, 4, 5 }, 0);
        result = fourSum.CalculateFourSum(new int[] { -3, -2, -1, 0, 0, 1, 2, 3 }, 0);
        result = fourSum.CalculateFourSum(new int[] { 0, 0, 0, 0 }, 0);
    }
}
