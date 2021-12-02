using AlgorithmsCSharp.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsCSharp.Mathematical
{
    //Fisher–Yates shuffle algorithm
    public class FYShuffle
    {
        public void Shuffle(object[] items)
        {
            var length = items.Length;
            var random = new Random();
            for (int i = 0; i < length; i++)
            {
                var r = random.Next(i + 1);
                ArrayHelper.Swap(items, i, r);
            }
        }
    }
}
