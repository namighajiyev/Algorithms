using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsCSharp.Collections.PriorityQueue
{
    public class BinaryHeapMinPQ<T> : IMinPriorityQueue<T> where T : class, IComparable
    {
        private T[] queue;
        private int itemCount;

        public BinaryHeapMinPQ(int capacity)
        {
            this.queue = new T[capacity + 1];
        }

        public void Insert(T item)
        {
            queue[++itemCount] = item;
            Swim(itemCount);
        }

        private void Swim(int startIndex)
        {
            while (startIndex > 1 && ArrayHelper.IsGreater(queue[startIndex / 2], queue[startIndex]))
            {
                ArrayHelper.Swap(queue, startIndex / 2, startIndex);
                startIndex = startIndex / 2;
            }
        }
        public T DeleteMin()
        {
            ThrowExceptionIfIsEmpty();
            T max = queue[1];//root
            ArrayHelper.Swap(queue, 1, itemCount--);
            Sink(1);
            queue[itemCount + 1] = null;//
            return max;
        }

        private void Sink(int startIndex)
        {
            Sink(queue, startIndex, itemCount);
        }

        public static void Sink(T[] queue, int startIndex, int itemCount)
        {
            while (2 * startIndex <= itemCount)
            {
                var j = 2 * startIndex;
                if (j < itemCount && ArrayHelper.IsGreater(queue[j], queue[j + 1])) { j++; }
                if (!ArrayHelper.IsGreater(queue[startIndex], queue[j])) { break; }
                ArrayHelper.Swap(queue, startIndex, j);
                startIndex = j;
            }
        }

        public bool IsEmpty()
        {
            return itemCount == 0;
        }

        public T Min()
        {
            ThrowExceptionIfIsEmpty();
            return queue[1];
        }

        private void ThrowExceptionIfIsEmpty()
        {
            if (IsEmpty()) throw new InvalidOperationException("Priority queue underflow");
        }
    }
}
