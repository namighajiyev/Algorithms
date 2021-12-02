using AlgorithmsCSharp.Collections;
using AlgorithmsCSharp.Mathematical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsCSharp.Sorting
{
    public class QuickSort : ISortAlgorithm
    {
        public void Sort(IComparable[] items)
        {
            new FYShuffle().Shuffle(items);
            Sort(items, 0, items.Length - 1);
        }

        private void Sort(IComparable[] items, int startIndex, int endIndex)
        {
            if (endIndex <= startIndex) { return; }
            int j = Partition(items, startIndex, endIndex);
            Sort(items, startIndex, j - 1);
            Sort(items, j + 1, endIndex);

        }

        public static int Partition(IComparable[] items, int startIndex, int endIndex)
        {
            int i = startIndex, j = endIndex + 1;
            while (true)
            {
                while (ArrayHelper.IsLess(items[++i], items[startIndex]))
                {
                    if (i == endIndex) { break; }
                }

                while (ArrayHelper.IsLess(items[startIndex], items[--j]))
                {
                    if (j == startIndex) { break; }
                }

                if (i >= j) { break; }

                ArrayHelper.Swap(items, i, j);
            }

            ArrayHelper.Swap(items, startIndex, j);
            return j;
        }


    }
}
