using AlgorithmsCSharp.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsCSharp.Sorting
{
    public class SelectionSort : ISortAlgorithm
    {
        public void Sort(IComparable[] items)
        {
            int length = items.Length;
            int min = 0;
            for (int i = 0; i < length; i++)
            {
                min = i;
                for (int j = i + 1; j < length; j++)
                {
                    if (ArrayHelper.IsLess(items[j], items[min]))
                    {
                        min = j;
                    }
                }

                ArrayHelper.Swap(items, i, min);
            }
        }
    }
}
