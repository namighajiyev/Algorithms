using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsCSharp.Collections.PriorityQueue
{
    public class UnorderedMaxPQ<T> : IMaxPriorityQueue<T> where T : class, IComparable
    {
        private T[] queue;
        private int itemCount;

        public UnorderedMaxPQ(int capacity)
        {
            this.queue = new T[capacity + 1];
        }

        public bool IsEmpty()
        {
            return itemCount == 0;
        }

        public void Insert(T item)
        {
            queue[itemCount++] = item;
        }

        public T DeleteMax()
        {
            ThrowExceptionIfIsEmpty();
            int max = FindIndexOfMax();
            ArrayHelper.Swap(queue, max, itemCount - 1);
            return queue[--itemCount];
        }


        public T Max()
        {
            ThrowExceptionIfIsEmpty();
            int max = FindIndexOfMax();
            return queue[max];
        }

        private int FindIndexOfMax()
        {
            int max = 0;
            for (int i = 1; i < itemCount; i++)
            {
                if (ArrayHelper.IsLess(queue[max], queue[i]))
                {
                    max = i;
                }
            }

            return max;
        }

        private void ThrowExceptionIfIsEmpty()
        {
            if (IsEmpty()) throw new InvalidOperationException("Priority queue underflow");
        }

    }
}
