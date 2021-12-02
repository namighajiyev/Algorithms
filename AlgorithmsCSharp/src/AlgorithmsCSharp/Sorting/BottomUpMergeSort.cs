using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsCSharp.Sorting
{
    public class BottomUpMergeSort : ISortAlgorithm
    {
        public void Sort(IComparable[] items)
        {
            var length = items.Length;
            var helperArray = new IComparable[length];
            for (int subarraySize = 1; subarraySize < length; subarraySize += subarraySize)//1,2,4,8,16,32
            {
                for (int startIndex = 0; startIndex < length - subarraySize; startIndex += subarraySize + subarraySize)
                {
                    int middleIndex = startIndex + subarraySize - 1,
                        endIndex = Math.Min(middleIndex + subarraySize, length - 1);
                    MergeSort.Merge(items, helperArray, startIndex, middleIndex, endIndex);
                }
            }
        }
    }
}
