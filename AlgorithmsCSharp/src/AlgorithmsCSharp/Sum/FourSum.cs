using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithmsCSharp.src.AlgorithmsCSharp.Sum;
public class FourSum
{
    public IList<IList<int>> CalculateFourSum(int[] nums, int target)
    {
        Array.Sort(nums);
        IList<IList<int>> result = new List<IList<int>>();

        for (int i = 0; i < nums.Length - 3; i++)
        {
            while (i != 0 && i < nums.Length && nums[i] == nums[i - 1]) { i++; }
            for (int j = nums.Length - 1; j > i; j--)
            {
                while (j != nums.Length - 1 && j > 0 && nums[j] == nums[j + 1]) { j--; }
                var newTarget = target - (nums[i] + nums[j]);
                int lo = i + 1, hi = j - 1;
                while (lo < hi)
                {
                    int currentSum = nums[lo] + nums[hi];
                    if (currentSum < newTarget || lo != i + 1 && nums[lo] == nums[lo - 1])
                    {
                        lo++;
                    }
                    else if (currentSum > newTarget || hi != j - 1 && nums[hi] == nums[hi + 1])
                    {
                        hi--;
                    }
                    else
                    {
                        result.Add(new int[] { nums[i], nums[lo++], nums[hi--], nums[j] });
                    }
                }
            }
        }
        return result;
    }
}