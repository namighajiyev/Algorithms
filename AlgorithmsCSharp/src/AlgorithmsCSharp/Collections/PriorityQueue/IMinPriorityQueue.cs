using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsCSharp.Collections.PriorityQueue
{
    public interface IMinPriorityQueue<T> where T : class, IComparable
    {
        bool IsEmpty();
        void Insert(T item);
        T DeleteMin();
        T Min();
    }
}
