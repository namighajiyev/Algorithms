using AlgorithmsCSharp.Collections;
using AlgorithmsCSharp.Mathematical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsCSharp.Sorting
{
    public class Dijkstra3WayQuickSort : ISortAlgorithm
    {
        public void Sort(IComparable[] items)
        {
            new FYShuffle().Shuffle(items);
            Sort(items, 0, items.Length - 1);
        }

        private static void Sort(IComparable[] items, int startIndex, int endIndex)
        {

            if (endIndex <= startIndex) { return; }

            int ltIndex = startIndex, eqIndex = startIndex, gtIndex = endIndex;
            IComparable partitionElement = items[startIndex];

            while (eqIndex <= gtIndex)
            {
                var cmpResult = items[eqIndex].CompareTo(partitionElement);
                if (cmpResult < 0) { ArrayHelper.Swap(items, ltIndex++, eqIndex++); }
                else if (cmpResult > 0) { ArrayHelper.Swap(items, eqIndex, gtIndex--); }
                else { eqIndex++; }
            }

            Sort(items, startIndex, ltIndex - 1);
            Sort(items, gtIndex + 1, endIndex);
        }

    }
}
