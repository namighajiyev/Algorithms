using AlgorithmsCSharp.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsCSharp.Sorting
{
    public class MergeSort : ISortAlgorithm
    {
        public void Sort(IComparable[] items)
        {
            var helperArray = new IComparable[items.Length];
            Sort(items, helperArray, 0, items.Length - 1);
        }

        private void Sort(IComparable[] items, IComparable[] helperArray, int startIndex, int endIndex)
        {
            if (endIndex <= startIndex) { return; }
            int middleIndex = startIndex + (endIndex - startIndex) / 2;
            Sort(items, helperArray, startIndex, middleIndex);
            Sort(items, helperArray, middleIndex + 1, endIndex);
            if (!ArrayHelper.IsLess(items[middleIndex + 1], items[middleIndex])) { return; }//improvement
            Merge(items, helperArray, startIndex, middleIndex, endIndex);
        }

        public static void Merge(IComparable[] items, IComparable[] helperArray, int startIndex, int middleIndex, int endIndex)
        {
            //copy to helperArray
            for (int k = startIndex; k <= endIndex; k++)
            {
                helperArray[k] = items[k];
            }
            int i = startIndex, j = middleIndex + 1;

            for (int k = startIndex; k <= endIndex; k++)
            {
                if (i > middleIndex) { items[k] = helperArray[j++]; }
                else if (j > endIndex) { items[k] = helperArray[i++]; }
                else if (ArrayHelper.IsLess(helperArray[j], helperArray[i])) { items[k] = helperArray[j++]; }
                else { items[k] = helperArray[i++]; }
            }
        }
    }
}
