using AlgorithmsCSharp.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsCSharp.Sorting
{
    public class InsertionSort : ISortAlgorithm
    {
        public void Sort(IComparable[] items)
        {
            var length = items.Length;
            for (int i = 0; i < length; i++)
            {
                for (int j = i; j > 0 && ArrayHelper.IsLess(items[j], items[j - 1]); j--)
                {
                    ArrayHelper.Swap(items, j, j - 1);
                }
            }
        }
    }
}
