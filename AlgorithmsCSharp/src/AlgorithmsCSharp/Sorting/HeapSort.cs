using AlgorithmsCSharp.Collections;
using AlgorithmsCSharp.Collections.PriorityQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsCSharp.Sorting
{
    public class HeapSort : ISortAlgorithm
    {
        public void Sort(IComparable[] items)
        {
            int itemCount = items.Length - 1;

            for (int startIndex = itemCount / 2; startIndex >= 0; startIndex--)
            {
                BinaryHeapMaxPQ<IComparable>.Sink(items, startIndex, itemCount);
            }

            while (itemCount > 0)
            {
                ArrayHelper.Swap(items, 0, itemCount--);
                BinaryHeapMaxPQ<IComparable>.Sink(items, 0, itemCount);
            }
        }

    }
}
