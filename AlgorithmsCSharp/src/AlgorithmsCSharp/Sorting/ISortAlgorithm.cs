using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsCSharp.Sorting
{
    public interface ISortAlgorithm
    {
        void Sort(IComparable[] items);
    }
}
