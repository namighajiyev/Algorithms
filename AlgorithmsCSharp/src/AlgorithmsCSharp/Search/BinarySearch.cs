using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsCSharp.Search
{
    public class BinarySearch
    {
        public int Search(int[] items, int searchedItem)
        {

            int start = 0;
            int end = items.Length - 1;
            while (start <= end)
            {
                int middle = start + (end - start) / 2;
                if (searchedItem < items[middle])
                {
                    end = middle - 1;
                }
                else if (searchedItem > items[middle])
                {
                    start = middle + 1;
                }
                else
                {
                    return middle;
                }
            }
            return -1;
        }
    }
}
