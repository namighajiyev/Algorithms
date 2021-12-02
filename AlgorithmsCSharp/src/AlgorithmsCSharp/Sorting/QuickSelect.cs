using AlgorithmsCSharp.Mathematical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsCSharp.Sorting
{
    public class QuickSelect
    {

        public IComparable Select(IComparable[] items, int k)
        {
            new FYShuffle().Shuffle(items);

            int startIndex = 0, endIndex = items.Length - 1;

            while (endIndex > startIndex)
            {
                int j = QuickSort.Partition(items, startIndex, endIndex);

                if (j < k) { startIndex = j + 1; }
                else if (j > k) { endIndex = j - 1; }
                else { return items[k]; }
            }
            return items[k];
        }
    }
}
