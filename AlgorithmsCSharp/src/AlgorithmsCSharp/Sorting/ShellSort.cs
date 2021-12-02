using AlgorithmsCSharp.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsCSharp.Sorting
{
    public class ShellSort : ISortAlgorithm
    {
        public void Sort(IComparable[] items)
        {
            int length = items.Length;
            int h = 1;

            while (h < length / 3)
            {
                h = 3 * h + 1; //1, 4, 13, 40, 121, 364 ...
            }

            while (h >= 1)
            {
                for (int i = h; i < length; i++)
                {
                    for (int j = i; j >= h && ArrayHelper.IsLess(items[j], items[j - h]); j -= h)
                    {
                        ArrayHelper.Swap(items, j, j - h);
                    }
                }

                h = h / 3;
            }









        }


    }
}
