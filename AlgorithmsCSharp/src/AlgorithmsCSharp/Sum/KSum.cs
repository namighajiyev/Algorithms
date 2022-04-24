using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithmsCSharp.src.AlgorithmsCSharp.Sum;

public class KSum
{
    public List<List<int>> CalculateKSum(int[] nums, int target, int start, int k)
    {
        List<List<int>> res = new List<List<int>>();

        // If we have run out of numbers to add, return res.
        if (start == nums.Length)
        {
            return res;
        }

        // There are k remaining values to add to the sum. The 
        // average of these values is at least target / k.
        int average_value = target / k;

        // We cannot obtain a sum of target if the smallest value
        // in nums is greater than target / k or if the largest 
        // value in nums is smaller than target / k.
        if (nums[start] > average_value || average_value > nums[nums.Length - 1])
        {
            return res;
        }

        if (k == 2)
        {
            return twoSum(nums, target, start);
        }

        for (int i = start; i < nums.Length; ++i)
        {
            if (i == start || nums[i - 1] != nums[i])
            {
                foreach (List<int> subset in CalculateKSum(nums, target - nums[i], i + 1, k - 1))
                {
                    res.Add(new List<int>() { { nums[i] } });
                    res[res.Count - 1].AddRange(subset);
                }
            }
        }

        return res;
    }

    List<List<int>> twoSum(int[] nums, int target, int start)
    {
        List<List<int>> res = new List<List<int>>();
        int lo = start, hi = nums.Length - 1;

        while (lo < hi)
        {
            int currSum = nums[lo] + nums[hi];
            if (currSum < target || (lo > start && nums[lo] == nums[lo - 1]))
            {
                ++lo;
            }
            else if (currSum > target || (hi < nums.Length - 1 && nums[hi] == nums[hi + 1]))
            {
                --hi;
            }
            else
            {
                res.Add(new List<int>() { nums[lo++], nums[hi--] });
            }
        }

        return res;
    }

}
